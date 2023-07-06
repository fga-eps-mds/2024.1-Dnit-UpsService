using Microsoft.AspNetCore.Mvc;
using repositorio.Interfaces;


namespace app.Controllers
{
    [ApiController]
    [Route("api")]
    public class UpsController : ControllerBase
    {
        private readonly IUpsRepositorio upsRepositorio;

        public UpsController(IUpsRepositorio upsRepositorio)
        {
            this.upsRepositorio = upsRepositorio;
        }

        [HttpGet("ups")]
        public IActionResult ObterUps()
        {
            return Ok();
        }
    }
}