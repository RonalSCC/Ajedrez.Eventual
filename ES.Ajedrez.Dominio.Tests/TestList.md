## Lista de pruebas



### Tablero
#### Contexto
📏 Dimensiones del tablero de ajedrez
El tablero es un cuadrado dividido en 8 filas (llamadas ranks, numeradas del 1 al 8) y 8 columnas (llamadas files, etiquetadas de "a" a "h").

En total hay 64 casillas (8x8).

🎨 Colores de las posiciones
Las casillas alternan dos colores: tradicionalmente blanco (o crema) y negro (o marrón oscuro, verde oscuro, etc.).

Regla importante: la esquina inferior derecha (desde el punto de vista de cada jugador) debe ser una casilla blanca.

Sobre cómo se distribuyen:

La casilla a1 es negra.

La casilla h1 es blanca.

En cada fila, los colores se alternan, y también cambian de fila a fila.


- [x] - Debe ser la casilla del tablero blanca en la posición A1 
- [] - Si la casilla no existe Debe arrojar ArgumentException 
- [] - Debe ser la casilla del tablero blanca en la posición A1 y negra en la posición A8
- [] - Debe ser la casilla del tablero negra en la posición H1
- [] - Debe ser la casilla del tablero negra en la posición H1 y blanca en la posición H8
- [] - Debe ser la casilla del tablero blanca en la posición 4D y negra en la posición 7G.  