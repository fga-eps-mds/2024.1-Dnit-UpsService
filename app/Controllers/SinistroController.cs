using Microsoft.AspNetCore.Mvc;
using service.Interfaces;

namespace app.Controllers
{
    [ApiController]
    [Route("api/controller")]

    public class SinistroController : ControllerBase
    {

        private readonly ISinistroService sinistroService;

        public SinistroController(ISinistroService sinistroService)
        {
            this.sinistroService = sinistroService;
        }

        [HttpPost("cadastroSinistro")]
        public IActionResult CadastrarSinistro(IFormFile sinistros)
        {

        }
    }
}