using Microsoft.AspNetCore.Mvc;
using service.Interfaces;

namespace app.Controllers
{
    [ApiController]
    [Route("api/rodovia")]
    public class RodoviaController : ControllerBase
    {
        private readonly IRodoviaService rodoviaService;

        public RodoviaController(IRodoviaService rodoviaService)
        {
            this.rodoviaService = rodoviaService;
        }

        [Consumes("multipart/form-data")]
        [HttpPost("cadastrarRodoviaPlanilha")]
        public async Task<IActionResult> EnviarPlanilha(IFormFile arquivo)
        {
            try
            {
                if (arquivo == null || arquivo.Length == 0)
                    return BadRequest("Nenhum arquivo enviado.");


                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    if (rodoviaService.SuperaTamanhoMaximo(memoryStream))
                    {
                        return StatusCode(406, "Tamanho m�ximo de arquivo ultrapassado!");
                    }
                }

                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    rodoviaService.CadastrarRodoviaViaPlanilha(memoryStream);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Arquivo incompat�vel");
            }
        }

    }
}