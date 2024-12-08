namespace COTO.Concesionario.Interfaces.DTO
{
    public class SportDTO : CocheDTO
    {
        public SportDTO()
        {
            PorcentajeImpuesto = IMPUESTO_SPORT;
            Precio = PRECIO_SPORT;
            TipoCoche = Enum.TipoCoche.Sport;
        }
    }
}
