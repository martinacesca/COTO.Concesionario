using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Enum;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace COTO.Concesionario.DataAccess
{
    public class CentroDtoJsonConverter : JsonConverter<CentroDTO>
    {
        public override CentroDTO Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                var tipoCentroJson = document.RootElement.GetProperty("Locacion").ToString();
                try
                {
                    var tipoCentro = (Centro)Enum.Parse(typeof(Centro), tipoCentroJson);

                    return new CentroDTO
                    {
                        Locacion = tipoCentro.ToString()
                    };
                }
                catch (Exception)
                {
                    throw new JsonException($"Tipo de centro '{tipoCentroJson}' no valido");
                }
            }

        }

        public override void Write(Utf8JsonWriter writer, CentroDTO value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }

}
