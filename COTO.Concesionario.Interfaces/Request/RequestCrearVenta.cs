namespace COTO.Concesionario.Interfaces.Request
{
    public class RequestCrearVenta
    {
        public required string TipoCoche { get; set; }
        public required string Centro { get; set; }
    }
}
