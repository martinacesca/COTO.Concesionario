using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Reader;
using Serilog;
using System.Text.Json;

namespace COTO.Concesionario.DataAccess
{
    public class MockJsonReader(ILogger logger) : IReader
    {
        public const string VENTAS_FILE_NAME = "ventas.json";

        private List<VentaDTO>? _ventas;

        public List<VentaDTO> Ventas 
        { 
            get 
            {
                if (_ventas == null)
                {
                    CargarVentas();
                }
                return _ventas!;
            }
            set 
            {
                _ventas = value;
            }
        }

        private readonly ILogger _logger = logger;

        private void CargarVentas()
        {
            try
            {
                var archivo = Path.Combine(AppContext.BaseDirectory, VENTAS_FILE_NAME);
                if (File.Exists(archivo))
                {
                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new CentroDtoJsonConverter());
                    options.Converters.Add(new CocheDtoJsonConverter());

                    Ventas = JsonSerializer.Deserialize<List<VentaDTO>>(File.ReadAllText(archivo), options) ?? new List<VentaDTO>();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al leer el archivo de ventas");
                throw;
            }
        }
    }
}
