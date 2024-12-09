using COTO.Concesionario.Interfaces.Enum;
using System.Text.Json.Serialization;

namespace COTO.Concesionario.Interfaces.DTO
{
    public class VolumenVentasDTO(IEnumerable<VentaDTO> ventas)
    {
        public decimal Monto { get; set; } = ventas.Sum(v => v.Coche.PrecioFinal);
        public int Cantidad { get; set; } = ventas.Count();
        override public string ToString() => $"Se vendió un total de: ${Monto} en un total de {Cantidad} ventas.";
    }

    public class VolumenVentasPorCentroDTO : VolumenVentasDTO
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Centro Centro { get; set; }
        public VolumenVentasPorCentroDTO(Centro centro, IEnumerable<VentaDTO> ventas) : base(ventas.Where(v => v.Centro.Centro == centro))
        {
            Centro = centro;
        }

        override public string ToString() => $"Se vendió un total de: ${Monto} en un total de {Cantidad} ventas en el centro {Centro}.";
    }
}
