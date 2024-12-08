using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Enum;
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
                try
                {
                    var tipoCoche = (TipoCoche)Enum.Parse(typeof(TipoCoche), tipoCocheJson);

                    return tipoCoche switch
                    {
                        TipoCoche.Sedan => new SedanDTO(),
                        TipoCoche.Suv => new SuvDTO(),
                        TipoCoche.Offroad => new OffroadDTO(),
                        TipoCoche.Sport => new SportDTO(),
                        _ => throw new JsonException($"Tipo de coche '{tipoCocheJson}' no valido")
                    };
                }
                catch (Exception)
                {
                    throw new JsonException($"Tipo de coche '{tipoCocheJson}' no valido");
                }
            }

        }

        public override void Write(Utf8JsonWriter writer, CocheDTO value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }

}
