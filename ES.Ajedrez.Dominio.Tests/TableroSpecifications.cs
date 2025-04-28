using ES.Ajedrez.Dominio.Aggregate;
using ES.Ajedrez.Dominio.Comandos;
using ES.Ajedrez.Dominio.Comandos;
using ES.Ajedrez.Dominio.Eventos;
using FluentAssertions;

namespace ES.Ajedrez.Dominio.Tests;

public class TableroSpecifications : CommandHandlerAsyncTest<CrearJuego, Guid>
{
    protected override ICommandHandlerAsync<CrearJuego, Guid> Handler => new CrearJuegoHandlerAsync(eventStore);

    [Fact]
    public async Task Debe_SerLaCasillaDelTableroBlancaEnLaPosicionA1()
    {
        _aggregateId = await WhenAsync(new CrearJuego());
        
        Then(new EventosAjedrez.JuegoCreado(_aggregateId));
        And<AjedrezGame>(ajedrez => ajedrez.Id, _aggregateId);
        var casillasEsperadas = new List<Casilla>()
        {
            new("A", 1, "Blanca"),
        };
        And<AjedrezGame>(ajedrez => ajedrez.Casillas, casillasEsperadas, onlyContains: true);
    }

    [Fact]
    public async Task Debe_SerLaCasillaDeTableroBlancaEnlaPosicionA1YNegraEnLaPosicionA8()
    {
        _aggregateId = await WhenAsync(new CrearJuego());
        
        Then(new EventosAjedrez.JuegoCreado(_aggregateId));
        var casillasEsperadas = new List<Casilla>()
        {
            new("A", 1, "Blanca"),
            new("A", 8, "Negra")
        };
        And<AjedrezGame>(ajedrez => ajedrez.Casillas, casillasEsperadas);
    }

    [Fact]
    public async Task Debe_SerLaCasillaDelTableroNegraEnLaPosicionH1YBlancaEnLaPosicionH8()
    {
        _aggregateId = await WhenAsync(new CrearJuego());
        
        Then(new EventosAjedrez.JuegoCreado(_aggregateId));
        var casillasEsperadas = new List<Casilla>()
        {
            new("A", 1, "Blanca"),
            new("A", 8, "Negra"),
            new("H", 1, "Negra"),
            new("H", 8, "Blanca")
        };
        And<AjedrezGame>(ajedrez => ajedrez.Casillas, casillasEsperadas);
    }
}