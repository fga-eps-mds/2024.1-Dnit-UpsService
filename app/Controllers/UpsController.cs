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
        public async Task<IActionResult> CalcularUpsSinistrosAsync()
        {
            await upsService.CalcularUpsEmMassaAsync();
            return Ok();
        }

        [HttpGet("calcular/ups/escola")]
        public async Task<IActionResult> CalcularUpsEscolaAsync([FromQuery] Escola escola, [FromQuery] double? raioKm)
        {
            double raio = 2.0;
            if (raioKm != null)
                raio = (double) raioKm;
            var upsDetalhado = await upsService.CalcularUpsEscolaAsync(escola, raio);
            return new OkObjectResult(upsDetalhado);
        }
    }
}