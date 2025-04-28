using ES.Ajedrez.Dominio.Eventos;

namespace ES.Ajedrez.Dominio.Aggregate;

public class AjedrezGame : AggregateRoot
{
    public Guid Id { get; private set; }
    private List<Casilla> _casillas = new();

    public void Apply(EventosAjedrez.JuegoCreado @event)
    {
        Id = @event.Id;
        _casillas.Add(new Casilla("A", 1,  "Blanca"));
    }

    public Casilla? ObtenerValorCasilla(int fila, string columna) 
        => _casillas.FirstOrDefault(cas => cas.Fila == fila && cas.Columna == columna);
}

public record Casilla(string Columna, int Fila , string Color);