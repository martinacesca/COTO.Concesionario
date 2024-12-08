namespace COTO.Concesionario.Interfaces.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public required CentroDTO Centro { get; set; }
        public required CocheDTO Coche { get; set; }
    }
}
