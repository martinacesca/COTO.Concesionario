using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Logic;
using System.Data;

namespace COTO.Concesionario.BusinessLogic
{
    public class VentasLogic(IVentasAccess ventasAccess) : IVentasLogic
    {
        public VentaDTO? AgregarVenta(VentaDTO venta)
        {
            var ventaCreada = ventasAccess.AgregarVenta(venta);
            return ventaCreada;
        }

        public IEnumerable<VentaDTO> GetVentas()
        {
            var ventas = ventasAccess.GetVentas();
            return ventas;
        }
    }
}
