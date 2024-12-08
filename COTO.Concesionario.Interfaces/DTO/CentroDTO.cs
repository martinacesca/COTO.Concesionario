using COTO.Concesionario.Interfaces.Enum;

namespace COTO.Concesionario.Interfaces.DTO
{
    public class CentroDTO
    {
        public string Locacion { get; set; }

        public CentroDTO(string centro)
        {
            try
            {
                var tipoCentro = (Centro)System.Enum.Parse(typeof(Centro), centro);
                Locacion = tipoCentro.ToString();
            }
            catch (Exception)
            {
                throw new InvalidDataException($"Tipo de centro '{centro}' no valido");
            }
        }
    }
}
