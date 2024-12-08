using COTO.Concesionario.Interfaces.DTO;
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
                return new CentroDTO(tipoCentroJson);
            }

        }

        public override void Write(Utf8JsonWriter writer, CentroDTO value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }

}
