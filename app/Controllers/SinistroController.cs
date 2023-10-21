using dominio;
using Microsoft.AspNetCore.Http;
using service;
using Microsoft.AspNetCore.Mvc;
using service.Interfaces;
using System;
using System.ComponentModel;
using System.IO;
using app.Services;
using Microsoft.AspNetCore.Authorization;


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
        public async Task<IActionResult> EnviarPlanilha(IFormFile arquivo)
        {
            authService.Require(User, Permissao.SinistroCadastrar);
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
                        return StatusCode(406, "Tamanho máximo de arquivo ultrapassado!");
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
