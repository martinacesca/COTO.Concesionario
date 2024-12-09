using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Request;

namespace COTO.Concesionario.Interfaces.Logic
{
    public interface IVentasLogic
    {
        Task<VentaDTO> AgregarVenta(RequestCrearVenta venta);
        Task<IEnumerable<VentaDTO>> GetVentas();
        Task<VolumenVentasDTO> GetVolumenVentas();
        Task<IList<string>> GetVolumenVentasPorCentro();
        Task<IEnumerable<PorcentajeVentaDTO>> GetPorcentajesVentas(); 

    }
}
