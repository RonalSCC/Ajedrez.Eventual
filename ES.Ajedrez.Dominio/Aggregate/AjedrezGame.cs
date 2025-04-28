using ES.Ajedrez.Dominio.Eventos;

namespace ES.Ajedrez.Dominio.Aggregate;

public class AjedrezGame : AggregateRoot
{
    public Guid Id { get; private set; }
    public List<Casilla> Casillas = new();

    public void Apply(EventosAjedrez.JuegoCreado @event)
    {
        Id = @event.Id;
        IniciarCasillas();
    }

    public void IniciarCasillas()
    {
        for (int posicionFila = 1; posicionFila <= 8; posicionFila++)
        {
            ColoresCasilla colorActual = posicionFila % 2 == 0 ? ColoresCasilla.Blanco : ColoresCasilla.Negro;
            for (int posicionColumna = 1; posicionColumna <= 8; posicionColumna++)
            {
                Casillas.Add(new Casilla((Columnas)posicionColumna, posicionFila, colorActual));
                colorActual = CambiarColorCasilla(colorActual);
            }
        }
    }

    private static ColoresCasilla CambiarColorCasilla(ColoresCasilla colorActual)
    {
        return colorActual == ColoresCasilla.Blanco ? ColoresCasilla.Negro : ColoresCasilla.Blanco;
    }
}

public enum Columnas
{
    A = 1,
    B = 2,
    C = 3,
    D = 4,
    E = 5,
    F = 6,
    G = 7,
    H = 8
}

public enum ColoresCasilla
{
    Blanco,
    Negro
}

public record Casilla(Columnas Columna, int Fila, ColoresCasilla Color);