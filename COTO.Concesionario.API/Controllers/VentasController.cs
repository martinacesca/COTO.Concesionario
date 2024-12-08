using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Logic;
using COTO.Concesionario.Interfaces.Request;
using Microsoft.AspNetCore.Mvc;

namespace COTO.Concesionario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController(
        ILogger<VentasController> logger,
        IVentasLogic ventasLogic) : ControllerBase
    {
        private readonly ILogger<VentasController> _logger = logger;

        [HttpPost]
        public IActionResult PostVenta([FromBody] RequestCrearVenta venta)
        {
            try
            { 
                var ventaCreada = ventasLogic.AgregarVenta(venta);
                return Ok(ventaCreada);
            }
            catch(InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VentaDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVentas()
        {
            try
            {
                var ventas = ventasLogic.GetVentas();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las ventas");
                return StatusCode(500, $"Error al obtener las ventas. {ex.Message}");
            }
        }
    }
}
