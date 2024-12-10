using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Reader;

namespace COTO.Concesionario.DataAccess
{
    public class VentasAccess(IReader reader) : IVentasAccess
    {
        public async Task<VentaDTO> AgregarVenta(VentaDTO venta)
        {
            var ventas = await reader.GetVentas();
            venta.Id = ventas.Count > 0 ? ventas.Max(v => v.Id) + 1 : 1;

            reader.Ventas?.Add(venta);
            await reader.GuardarVentas();

            return venta;
        }

        public async Task<IEnumerable<VentaDTO>> GetVentas()
        {
            var ventas = await reader.GetVentas();
            return ventas;
        }
    }
}
