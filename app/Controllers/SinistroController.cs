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

        [Consumes("multipart/form-data")]
        [HttpPost("cadastrarSinistroPlanilha")]

        public async Task<IActionResult> EnviarPlanilha(IFormFile arquivo)
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