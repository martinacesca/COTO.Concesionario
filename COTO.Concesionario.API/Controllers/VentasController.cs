using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Logic;
using COTO.Concesionario.Interfaces.Request;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VentaDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostVenta([FromBody] RequestCrearVenta venta)
        {
            try
            {
                var ventaCreada = await ventasLogic.AgregarVenta(venta);
                return StatusCode((int)HttpStatusCode.Created, ventaCreada);
            }
            catch (InvalidDataException ex)
            {
                _logger.LogError(ex, "Error al crear la venta");
                return BadRequest($"Error al crear la venta. {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VentaDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVentas()
        {
            try
            {
                var ventas = await ventasLogic.GetVentas();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las ventas");
                return StatusCode(500, $"Error al obtener las ventas. {ex.Message}");
            }
        }

        [HttpGet("Volumen")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVolumenVentas()
        {
            try
            {
                var volumen = await ventasLogic.GetVolumenVentas();
                return Ok(volumen.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el volumen de ventas");
                return StatusCode(500, $"Error al obtener el volumen de ventas. {ex.Message}");
            }
        }

        [HttpGet("Centro/Volumen")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVolumenVentasPorCentro()
        {
            try
            {
                // se optó por devolver una lista de strings con los volumenes de ventas por centro a modo de reporte
                var volumenes = await ventasLogic.GetVolumenVentasPorCentro();
                return Ok(volumenes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el volumen de ventas por centro");
                return StatusCode(500, $"Error al obtener el volumen de ventas por centro. {ex.Message}");
            }
        }

        [HttpGet("Centro/Porcentaje")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PorcentajeVentaDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPorcentajesVentas()
        {
            try
            {
                // se optó por devolver un objeto JSON con los porcentajes de ventas
                var porcentajes = await ventasLogic.GetPorcentajesVentas();
                return Ok(porcentajes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los porcentajes de ventas");
                return StatusCode(500, $"Error al obtener los porcentajes de ventas. {ex.Message}");
            }
        }
    }
}
