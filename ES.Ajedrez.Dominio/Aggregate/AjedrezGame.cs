using ES.Ajedrez.Dominio.Eventos;

namespace ES.Ajedrez.Dominio.Aggregate;

public class AjedrezGame : AggregateRoot
{
    public Guid Id { get; private set; }
    public List<Casilla> Casillas = new();

    public void Apply(EventosAjedrez.JuegoCreado @event)
    {
        Id = @event.Id;
        Casillas.Add(new Casilla("A", 1,  "Blanca"));
    }
}

public record Casilla(string Columna, int Fila , string Color);