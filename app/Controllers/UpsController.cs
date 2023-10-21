using app.Services;
using dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using repositorio.Interfaces;
using service.Interfaces;
using System.ComponentModel;

namespace app.Controllers
{
    [ApiController]
    [Route("api")]
    public class UpsController : ControllerBase
    {
        private readonly IUpsService upsService;
        private readonly AuthService authService;

        public UpsController(IUpsService upsService, AuthService authService)
        {
            this.upsService = upsService;
            this.authService = authService;
        }

        [HttpGet("obter/sinistros")]
        [Authorize]
        public IActionResult ObterUps()
        {
            authService.Require(User, Permissao.SinistroVisualizar);
            IEnumerable<Sinistro> sinistros = upsService.ObterSinistros();
            return new OkObjectResult(sinistros);
        }

        [HttpPost("calcular/ups/sinistros")]
        [Authorize]
        public IActionResult CalcularUpsSinistros()
        {
            authService.Require(User, Permissao.UpsCalcularSinistro);
            upsService.CalcularUpsEmMassa();

            return Ok();
        }

        [HttpGet("calcular/ups/escola")]
        [Authorize]
        public IActionResult CalcularUpsEscola([FromQuery] Escola escola)
        {
            authService.Require(User, Permissao.UpsCalcularEscola);
            UpsDetalhado upsDetalhado = upsService.CalcularUpsEscola(escola);
            return new OkObjectResult(upsDetalhado);
        }
    }
}
