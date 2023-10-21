using api;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Service.Interfaces;


namespace app.Controllers
{
    [ApiController]
    [Route("api/sinistro")]
    public class SinistroController : ControllerBase
    {
        private readonly ISinistroService sinistroService;
        private readonly AuthService authService;
        
        public SinistroController(ISinistroService sinistroService, AuthService authService)
        {
            this.sinistroService = sinistroService;
            this.authService = authService;
        }
        
        
        [Consumes("multipart/form-data")]
        [HttpPost("cadastrarSinistroPlanilha")]
        [Authorize]
        public async Task<IActionResult> EnviarPlanilhaAsync(IFormFile arquivo)
        {
            authService.Require(User, Permissao.SinistroCadastrar);
            try
            {
                if (arquivo == null || arquivo.Length == 0)
                    throw new ApiException(ErrorCodes.ArquivoVazio);

                if (arquivo.ContentType.ToLower() != "text/csv")
                    throw new ApiException(ErrorCodes.ArquivoFormatoInvalido, "Formato deve CSV");

                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    if (sinistroService.SuperaTamanhoMaximo(memoryStream))
                    {
                        throw new ApiException(ErrorCodes.TamanhoArquivoExcedido);
                    }
                }

                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    sinistroService.CadastrarSinistroViaPlanilha(memoryStream);
                }

                return Ok();
            }
            catch (ApiException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}