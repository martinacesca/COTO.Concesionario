using COTO.Concesionario.Interfaces.DTO;

namespace COTO.Concesionario.Interfaces.Logic
{
    public interface IVentasLogic
    {
        VentaDTO? AgregarVenta(VentaDTO venta);
        IEnumerable<VentaDTO> GetVentas();
    }
}
