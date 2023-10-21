using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service;
using service.Interfaces;
using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json.Serialization;
using app.Services;
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
        public async Task<IActionResult> EnviarPlanilha(IFormFile arquivo)
        {
            authService.Require(User, Permissao.RodoviaCadastrar);
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Arquivo incompatível");
            }
        }

    }
}
