using ES.Ajedrez.API;
using ES.Ajedrez.Dominio;
using ES.Ajedrez.EventStore;

const string serviceName = "ES.Comandos";

var builder = WebApplication.CreateBuilder(args);

var martenConnectionString = builder.Configuration.GetConnectionString("MartenEventStore") ??
                             throw new ArgumentNullException(
                                 $"La cadena de conexión 'MartenEventStore' no está configurada.");
var openTelemetryEndpoint = builder.Configuration.GetValue<string>("OpenTelemetryEndpoint") ??
                            throw new ArgumentNullException(
                                $"La url de OpenTelemtry no está configurada.");
;

builder.Host.UsarSerilog(serviceName, openTelemetryEndpoint);
builder.Host.UsarWolverine(martenConnectionString, builder.Environment.IsDevelopment());

builder.Services.AddOpenApi();

builder.Services.AgregarOpenTelemtry(serviceName, openTelemetryEndpoint);
builder.Services.AgregarHealthChecks(martenConnectionString);
builder.Services.AgregarMartenEventStore();
builder.Services.AgregarWolverineRouter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.MapOpenApi();

// app.UseHttpsRedirection();
app.UseHealthChecks("/health");



app.MapPost("/IniciarJuego", () => Results.Problem());
app.Run();
public record IniciarJuegoRequest();


