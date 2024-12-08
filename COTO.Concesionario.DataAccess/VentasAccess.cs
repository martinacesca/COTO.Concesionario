using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Reader;

namespace COTO.Concesionario.DataAccess
{
    public class VentasAccess(IReader reader) : IVentasAccess
    {
        public VentaDTO AgregarVenta(VentaDTO venta)
        {
            venta.Id = reader.Ventas.Max(v => v.Id) + 1;

            reader.Ventas.Add(venta);
            reader.GuardarVentas();

            return venta;
        }

        public IEnumerable<VentaDTO> GetVentas()
        {
            var ventas = reader.Ventas;
            return ventas;
        }
    }
}
