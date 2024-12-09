using COTO.Concesionario.Interfaces.Enum;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace COTO.Concesionario.Interfaces.DTO
{
    public abstract class CocheDTO
    {
        #region Constantes
        public const decimal PRECIO_SEDAN = 8000;
        public const decimal PRECIO_SUV = 9500;
        public const decimal PRECIO_OFFROAD = 12500;
        public const decimal PRECIO_SPORT = 18200;
        public decimal IMPUESTO_SPORT = 0.07M;
        #endregion

        public decimal Precio { get; set; }
        public decimal PorcentajeImpuesto { get; set; } = 0;
        public decimal PrecioFinal => Precio + (Precio * PorcentajeImpuesto);

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoCoche TipoCoche { get; set; }

        public static CocheDTO CrearCoche(string coche)
        {
            try
            {
                var tipoCoche = (TipoCoche)System.Enum.Parse(typeof(TipoCoche), coche);
                return tipoCoche switch
                {
                    TipoCoche.Sedan => new SedanDTO(),
                    TipoCoche.Suv => new SuvDTO(),
                    TipoCoche.Offroad => new OffroadDTO(),
                    TipoCoche.Sport => new SportDTO(),
                    _ => throw new NotImplementedException()
                };
            }
            catch (Exception)
            {
                throw new InvalidDataException($"Tipo de coche '{coche}' no valido");
            }
        }

        override public string ToString() => TipoCoche.ToString();
    }
}
