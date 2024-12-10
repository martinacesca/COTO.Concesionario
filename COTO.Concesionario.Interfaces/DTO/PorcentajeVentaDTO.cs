using COTO.Concesionario.Interfaces.Enum;
using System.Text.Json.Serialization;

namespace COTO.Concesionario.Interfaces.DTO
{
    public class PorcentajeVentaDTO
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required TipoCoche TipoCoche { get; set; }
        public required IEnumerable<PorcentajeVenta> Porcentajes { get; set; }

        public class PorcentajeVenta
        {
            [JsonConverter(typeof(JsonStringEnumConverter))]
            public Centro Centro { get; set; }
            public decimal Porcentaje { get; set; }
            public required string PorcentajeFormateado { get; set; }

        }
    }
}
