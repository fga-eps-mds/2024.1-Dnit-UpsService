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

        public enum Permissao
        {
            [Description("Calcular o UPS")]
            CalcularUps = 5000,
        }

        [HttpGet("teste")]
        [Authorize]
        public int Teste()
        {
            authService.Require(User, Permissao.CalcularUps);
            return 42;
        }

        [HttpGet("obter/sinistros")]
        public IActionResult ObterUps()
        {
            IEnumerable<Sinistro> sinistros = upsService.ObterSinistros();

            return new OkObjectResult(sinistros);
        }

        [HttpPost("calcular/ups/sinistros")]
        public IActionResult CalcularUpsSinistros()
        {
            upsService.CalcularUpsEmMassa();

            return Ok();
        }

        [HttpGet("calcular/ups/escola")]
        public IActionResult CalcularUpsEscola([FromQuery] Escola escola)
        {
            UpsDetalhado upsDetalhado = upsService.CalcularUpsEscola(escola);
            return new OkObjectResult(upsDetalhado);
        }
    }
}