using System.Net;
using System.Net.Http.Json;
using FluentAssertions;

namespace ES.Ajedrez.Api.Tests;

public class CrearJuegoSpecifications : IClassFixture<ApiFactory>
{

    private readonly HttpClient _cliente;

    public CrearJuegoSpecifications(ApiFactory apiFactory)
    {
        _cliente = apiFactory.CreateClient();
    }
    
    [Fact]
    public async Task Si_EnEndpointFallaDebeRetornar500()
    {
        var response = await _cliente.PostAsJsonAsync("IniciarJuego", new IniciarJuegoRequest());

        response.Should().HaveStatusCode(HttpStatusCode.InternalServerError);
    }
}