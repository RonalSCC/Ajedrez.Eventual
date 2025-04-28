namespace ES.Ajedrez.Dominio.Comandos;

public record CrearJuego();
public class CrearJuegoHandlerAsync(IEventStore eventStore) : ICommandHandlerAsync<CrearJuego, Guid>
{
    public Task<Guid> HandleAsync(CrearJuego command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}