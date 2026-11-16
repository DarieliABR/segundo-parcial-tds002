# Segundo Parcial — Concurso (U5-U7)

**Materia:** Fundamentos de Programación (TDS-002)
**Docente:** Cristian E. Sánchez Ramírez

## Integrantes

- Joycel Otoniel Pérez Nieves — 2026-0703
- Darieli Alexandra Báez Rosario - 2026-0700
## Ronda 3 — Programa en vivo

El reto de la Ronda 3 está en la carpeta [SegundoParcial](./SegundoParcial).

### Cajero automático

Programa de consola que simula un cajero:

- Pide el PIN y da 3 intentos. Si se falla las 3 veces, la tarjeta se bloquea y el programa termina.
- Después muestra un menú que se repite hasta elegir 0: consultar saldo, depositar, retirar y ver el resumen de la sesión.
- El retiro tiene que ser múltiplo de RD$ 100, no puede pasar de RD$ 10,000 y no puede ser mayor que el saldo.
- Si se escribe algo que no es un número, el programa lo vuelve a pedir.

El saldo inicial es RD$ 5,000 y el PIN de prueba es `1234`.

### Lo que se usó de las unidades 5, 6 y 7

- **if / else if:** validar el PIN y las reglas del retiro.
- **switch:** las opciones del menú.
- **Ciclos:** `for` para los intentos del PIN, `do-while` para el menú y `while` para volver a pedir datos inválidos.
- **Métodos:** con parámetros y valor de retorno (`ValidarPin`, `LeerEntero`, `LeerMonto`, `Depositar`, `PuedeRetirar`, `Retirar`) y métodos `void` para mostrar el menú, el saldo y el resumen.

## Cómo ejecutarlo

```
cd SegundoParcial/CajeroAutomatico
dotnet run
```

Hecho con Visual Studio Code y .NET SDK 10.
