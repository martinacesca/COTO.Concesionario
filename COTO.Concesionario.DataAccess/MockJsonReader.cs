using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Reader;
using Serilog;
using System.Text.Json;

namespace COTO.Concesionario.DataAccess
{
    public class MockJsonReader(ILogger logger) : IReader
    {
        public const string VENTAS_FILE_NAME = "ventas.json";

        public List<VentaDTO>? Ventas { get; set; }

        public async Task<List<VentaDTO>> GetVentas()
        {
            if (Ventas == null)
            {
                await CargarVentas();
            }
            return Ventas!;
        }

        private readonly ILogger _logger = logger;

        private string RutaArchivo = Path.Combine(VENTAS_FILE_NAME);
        
        private async Task CargarVentas()
        {
            try
            {
                if (File.Exists(RutaArchivo))
                {
                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new CentroDtoJsonConverter());
                    options.Converters.Add(new CocheDtoJsonConverter());

                    var contenidoArchivo = await File.ReadAllTextAsync(RutaArchivo);
                    Ventas = JsonSerializer.Deserialize<List<VentaDTO>>(contenidoArchivo, options) ?? new List<VentaDTO>();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al leer el archivo de ventas");
                throw;
            }
        }

        public async Task GuardarVentas()
        {
            var options = new JsonSerializerOptions();
            var jsonVentas = JsonSerializer.Serialize(Ventas, options);

            await File.WriteAllTextAsync(RutaArchivo, jsonVentas);        
        }
    }
}
