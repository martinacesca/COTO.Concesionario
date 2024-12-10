using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Enum;
using COTO.Concesionario.Interfaces.Logic;
using COTO.Concesionario.Interfaces.Request;
using System.Globalization;
using System.Text;

namespace COTO.Concesionario.BusinessLogic
{
    public class VentasLogic(IVentasAccess ventasAccess) : IVentasLogic
    {
        public async Task<VentaDTO> AgregarVenta(RequestCrearVenta venta)
        {
            var ventaDto = new VentaDTO
            {
                Centro = new CentroDTO(ConvertToPascalCase(venta.Centro)),
                Coche = CocheDTO.CrearCoche(ConvertToPascalCase(venta.TipoCoche)),
            };

            var ventaCreada = await ventasAccess.AgregarVenta(ventaDto);
            return ventaCreada;
        }

        private static string ConvertToPascalCase(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input).Replace(" ", "");
        }

        public async Task<IEnumerable<VentaDTO>> GetVentas()
        {
            var ventas = await ventasAccess.GetVentas();
            return ventas;
        }

        public async Task<VolumenVentasDTO> GetVolumenVentas()
        {
            var ventas = await ventasAccess.GetVentas();
            return new VolumenVentasDTO(ventas);
        }

        public async Task<IList<string>> GetVolumenVentasPorCentro()
        {
            var ventas = await ventasAccess.GetVentas();
            var agrupados = ventas.GroupBy(v => v.Centro.Centro);
            var volumenes = new List<string>();
            foreach (var centro in agrupados)
            {
                volumenes.Add( new VolumenVentasPorCentroDTO(centro.Key, ventas).ToString() );
            }

            return volumenes;
        }

        public async Task<IEnumerable<PorcentajeVentaDTO>> GetPorcentajesVentas()
        {
            var ventas = await ventasAccess.GetVentas();
            var porcentajes = new List<PorcentajeVentaDTO>();


            var agrupados = ventas.GroupBy(v => v.Coche.TipoCoche);
            foreach (var tipoCoche in agrupados)
            {
                var porcentajeVenta = new PorcentajeVentaDTO
                {
                    TipoCoche = tipoCoche.Key,
                    Porcentajes = tipoCoche.GroupBy(v => v.Centro.Centro).Select(c => new PorcentajeVentaDTO.PorcentajeVenta
                    {
                        Centro = c.Key,
                        Porcentaje = (c.Count() / (decimal)tipoCoche.Count()) * 100,
                        PorcentajeFormateado = $"{(c.Count() / (decimal)tipoCoche.Count()) :0.#%}",
                       
                    }),
                };
                porcentajes.Add(porcentajeVenta);
            }

            return porcentajes;
        }
    }
}
