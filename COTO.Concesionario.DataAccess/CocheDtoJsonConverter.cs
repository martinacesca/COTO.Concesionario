using COTO.Concesionario.Interfaces.DTO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace COTO.Concesionario.DataAccess
{
    public class CocheDtoJsonConverter : JsonConverter<CocheDTO>
    {
        public override CocheDTO Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                var tipoCocheJson = document.RootElement.GetProperty("TipoCoche").ToString();
                return CocheDTO.CrearCoche(tipoCocheJson);
            }
        }

        public override void Write(Utf8JsonWriter writer, CocheDTO value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }

}
