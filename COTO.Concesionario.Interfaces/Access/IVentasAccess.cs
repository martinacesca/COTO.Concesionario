using COTO.Concesionario.Interfaces.DTO;

namespace COTO.Concesionario.Interfaces.Access
{
    public interface IVentasAccess
    {
        Task<VentaDTO> AgregarVenta(VentaDTO venta);
        Task<IEnumerable<VentaDTO>> GetVentas();
    }
}
