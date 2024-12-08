using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Request;

namespace COTO.Concesionario.Interfaces.Logic
{
    public interface IVentasLogic
    {
        VentaDTO? AgregarVenta(RequestCrearVenta venta);
        IEnumerable<VentaDTO> GetVentas();
    }
}
