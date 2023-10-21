using api;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers
{
    [ApiController]
    [Route("api/rodovia")]
    public class RodoviaController : ControllerBase
    {
        private readonly IRodoviaService rodoviaService;
        private readonly AuthService authService;
        
        public RodoviaController(IRodoviaService rodoviaService, AuthService authService)
        {
            this.rodoviaService = rodoviaService;
            this.authService = authService;
        }
        
        [Consumes("multipart/form-data")]
        [HttpPost("cadastrarRodoviaPlanilha")]
        [Authorize]
        public async Task<IActionResult> EnviarPlanilhaAsync(IFormFile arquivo)
        {
            authService.Require(User, Permissao.RodoviaCadastrar);
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

                    if (rodoviaService.SuperaTamanhoMaximo(memoryStream))
                        throw new ApiException(ErrorCodes.TamanhoArquivoExcedido);
                }

                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    rodoviaService.CadastrarRodoviaViaPlanilha(memoryStream);
                }

                return Ok();
            }
            catch (ApiException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Arquivo incompatível");
            }
        }
    }
}
