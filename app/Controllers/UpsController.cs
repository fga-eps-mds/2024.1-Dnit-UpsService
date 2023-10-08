using Entidades;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

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

        [HttpPost("calcular/ups/sinistros")]
        public async Task<IActionResult> CalcularUpsSinistros()
        {
            await upsService.CalcularUpsEmMassa();
            return Ok();
        }

        [HttpGet("calcular/ups/escola")]
        public async Task<IActionResult> CalcularUpsEscola([FromQuery] Escola escola)
        {
            var upsDetalhado = await upsService.CalcularUpsEscolaAsync(escola);
            return new OkObjectResult(upsDetalhado);
        }
    }
}