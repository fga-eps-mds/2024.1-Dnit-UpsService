using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service;
using service.Interfaces;
using System;
using System.IO;

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

                if (arquivo.ContentType.ToLower() != "text/csv")
                {
                    return BadRequest("O arquivo deve estar no formato CSV.");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    if (rodoviaService.SuperaTamanhoMaximo(memoryStream))
                    {
                        return StatusCode(406, "Tamanho máximo de arquivo ultrapassado!");
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}