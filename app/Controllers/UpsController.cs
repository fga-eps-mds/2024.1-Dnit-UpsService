using dominio;
using Microsoft.AspNetCore.Mvc;
using repositorio.Interfaces;
using service.Interfaces;

namespace app.Controllers
{
    [ApiController]
    [Route("api")]
    public class UpsController : ControllerBase
    {
        private readonly IUpsService upsService;

        public UpsController(IUpsService upsService)
        {
            this.upsService = upsService;
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