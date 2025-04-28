using ES.Ajedrez.Dominio.Aggregate;
using ES.Ajedrez.Dominio.Comandos;
using ES.Ajedrez.Dominio.Comandos;
using ES.Ajedrez.Dominio.Eventos;

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
    }
}