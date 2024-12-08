using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Logic;
using COTO.Concesionario.Interfaces.Request;

namespace COTO.Concesionario.BusinessLogic
{
    public class VentasLogic(IVentasAccess ventasAccess) : IVentasLogic
    {
        public VentaDTO? AgregarVenta(RequestCrearVenta venta)
        {
            var ventaDto = new VentaDTO
            {
                Centro = new CentroDTO(venta.Centro),
                Coche = CocheDTO.CrearCoche(venta.TipoCoche),
            };

            var ventaCreada = ventasAccess.AgregarVenta(ventaDto);
            return ventaCreada;
        }

        public IEnumerable<VentaDTO> GetVentas()
        {
            var ventas = ventasAccess.GetVentas();
            return ventas;
        }
    }
}
