using COTO.Concesionario.Interfaces.DTO;

namespace COTO.Concesionario.Interfaces.Access
{
    public interface IVentasAccess
    {
        VentaDTO? AgregarVenta(VentaDTO venta);
        IEnumerable<VentaDTO> GetVentas();
    }
}
