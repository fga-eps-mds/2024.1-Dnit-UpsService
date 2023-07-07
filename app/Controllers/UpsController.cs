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

        [HttpGet("sinistros")]
        public IActionResult ObterUps()
        {
            IEnumerable<Sinistro> sinistros = upsService.ObterSinistros();

            return new OkObjectResult(sinistros);
        }

        [HttpPost("sinistros/ups")]
        public IActionResult CalcularUpsSinistros()
        {
            upsService.CalcularUpsEmMassa();

            return Ok();
        }

        [HttpGet("escola/ups")]
        public IActionResult CalcularUpsEscola([FromQuery] Escola escola)
        {
            int ups = upsService.CalcularUpsEscola(escola);
            return new OkObjectResult(ups);
        }
    }
}