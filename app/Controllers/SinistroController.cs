using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;


namespace app.Controllers
{
    [ApiController]
    [Route("api/sinistro")]
    public class SinistroController : ControllerBase
    {
        private readonly ISinistroService sinistroService;

        public SinistroController(ISinistroService sinistroService)
        {
            this.sinistroService = sinistroService;
        }

        // Não segue o padrão de endpoints da classe pra manter
        // compatibilidade com o frontend.
        [HttpGet("/api/obter/sinistros")]
        public async Task<IActionResult> ObterUpsAsync()
        {
            var sinistros = await sinistroService.ObterTodosAsync();
            return new OkObjectResult(sinistros);
        }

        [Consumes("multipart/form-data")]
        [HttpPost("cadastrarSinistroPlanilha")]
        public async Task<IActionResult> EnviarPlanilhaAsync(IFormFile arquivo)
        {

            try
            {
                if (arquivo == null || arquivo.Length == 0)
                    return BadRequest("Nenhum arquivo enviado");

                if (arquivo.ContentType.ToLower() != "text/csv")
                {
                    return BadRequest("O arquivo deve estar no formato CSV.");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    if (sinistroService.SuperaTamanhoMaximo(memoryStream))
                    {
                        return StatusCode(406, "Tamanho m�ximo de arquivo ultrapassado!");
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}