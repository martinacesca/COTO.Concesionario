using Microsoft.AspNetCore.Mvc;

namespace COTO.Concesionario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController(ILogger<VentasController> logger) : ControllerBase
    {
        private readonly ILogger<VentasController> _logger = logger;

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get ventas");
            return Ok();
        }
    }
}
