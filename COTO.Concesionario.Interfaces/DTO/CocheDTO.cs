using COTO.Concesionario.Interfaces.Enum;

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
    }
}
