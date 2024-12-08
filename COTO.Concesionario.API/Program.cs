using COTO.Concesionario.API.Middlewares;
using COTO.Concesionario.BusinessLogic;
using COTO.Concesionario.DataAccess;
using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.Logic;
using COTO.Concesionario.Interfaces.Reader;
using COTO.Concesionario.Interfaces.Utils.Logger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSerilog(logger: LoggerService.CreateLogger());

builder.Services.AddScoped<IReader, MockJsonReader>();
builder.Services.AddScoped<IVentasAccess, VentasAccess>();
builder.Services.AddScoped<IVentasLogic, VentasLogic>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MedidorTiempoEjecucionMiddleware>();

app.MapControllers();

app.Run();
