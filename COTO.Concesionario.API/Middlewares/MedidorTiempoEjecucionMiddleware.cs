using System.Diagnostics;

namespace COTO.Concesionario.API.Middlewares
{
    public class MedidorTiempoEjecucionMiddleware
        (RequestDelegate next,
        ILogger<MedidorTiempoEjecucionMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            logger.LogInformation($"Tiempo de ejecucion de '{context.Request.Path}': {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
