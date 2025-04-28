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
            new(Columnas.A, 1, ColoresCasilla.Negro),
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
            new(Columnas.A, 1, ColoresCasilla.Negro),
            new(Columnas.A, 8, ColoresCasilla.Blanco)
        };
        And<AjedrezGame>(ajedrez => ajedrez.Casillas, casillasEsperadas, onlyContains:true);
    }

    [Fact]
    public async Task Debe_ElTableroTenerContenidasLasCasillas()
    {
        _aggregateId = await WhenAsync(new CrearJuego());
        
        Then(new EventosAjedrez.JuegoCreado(_aggregateId));
        var casillasEsperadas = new List<Casilla>()
        {
            new(Columnas.A, 1, ColoresCasilla.Negro),
            new(Columnas.A, 8, ColoresCasilla.Blanco),
            new(Columnas.H, 1, ColoresCasilla.Blanco),
            new(Columnas.H, 8, ColoresCasilla.Negro),
            new(Columnas.D, 4, ColoresCasilla.Negro),
            new(Columnas.G, 6, ColoresCasilla.Blanco),
        };
        And<AjedrezGame>(ajedrez => ajedrez.Casillas, casillasEsperadas, onlyContains:true);
    }
}