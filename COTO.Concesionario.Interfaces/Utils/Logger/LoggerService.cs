using Serilog;

namespace COTO.Concesionario.Interfaces.Utils.Logger
{
    public class LoggerService(ILogger logger) : ILoggerService
    {
        private readonly ILogger _logger = logger;

        public static ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .Enrich.WithCorrelationIdHeader(headerKey: "x-req-id")
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .Enrich.WithProcessId()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt",
                    shared: true,
                    outputTemplate: "{CorrelationId} {Timestamp:HH:mm:ss:fff} [{Level:u3}] ({ThreadId}) {Message}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 14).CreateLogger();
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception ex, string message)
        {
            _logger.Error(message, ex);
        }

        public void Info(string message)
        {
            _logger.Information(message);
        }

        public void Warn(string message)
        {
            _logger.Warning(message);
        }
    }
}
