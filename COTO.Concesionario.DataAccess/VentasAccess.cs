using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Reader;

namespace COTO.Concesionario.DataAccess
{
    public class VentasAccess(IReader reader) : IVentasAccess
    {
        public VentaDTO? AgregarVenta(VentaDTO venta)
        {
            if (reader.Ventas != null)
            { 
                reader.Ventas.Add(venta);
                return venta;
            }
            return null;
        }

        public IEnumerable<VentaDTO> GetVentas()
        {
            var ventas = reader.Ventas;
            return ventas;
        }
    }
}
