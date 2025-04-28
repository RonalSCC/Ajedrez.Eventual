using ES.Ajedrez.Dominio.Eventos;

namespace ES.Ajedrez.Dominio.Comandos;

public record CrearJuego();
public class CrearJuegoHandlerAsync(IEventStore eventStore) : ICommandHandlerAsync<CrearJuego, Guid>
{
    public Task<Guid> HandleAsync(CrearJuego command, CancellationToken cancellationToken = default)
    {
        var idJuego = Guid.CreateVersion7();
        var eventoJuegoCreado = new EventosAjedrez.JuegoCreado(idJuego);
        eventStore.AppendEvent(idJuego, eventoJuegoCreado);
        return Task.FromResult(idJuego);
    }
}