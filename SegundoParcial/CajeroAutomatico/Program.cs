using System;

/*
Nombre: Joycel Otoniel Pérez Nieves
Fecha: 15/11/2026
Descripción: Segundo Parcial, Ronda 3. Cajero automático que pide un PIN con 3 intentos
y después muestra un menú para consultar el saldo, depositar, retirar y ver un resumen
de la sesión. Usa if, switch, ciclos y métodos.
 */

namespace CajeroAutomatico
{
    class Program
    {
        const int PIN_CORRECTO = 1234;
        const int MAX_INTENTOS = 3;
        const double LIMITE_RETIRO = 10000;

        static void Main(string[] args)
        {
            double saldo = 5000;
            int depositos = 0;
            int retiros = 0;
            int opcion;

            Console.WriteLine("===== CAJERO AUTOMÁTICO =====");

            // si el PIN falla 3 veces la tarjeta se bloquea y el programa termina
            if (!ValidarPin())
            {
                Console.WriteLine("Tarjeta bloqueada. Comuníquese con su banco.");
                return;
            }

            do
            {
                MostrarMenu();
                opcion = LeerEntero("Elige una opción: ");

                switch (opcion)
                {
                    case 1:
                        MostrarSaldo(saldo);
                        break;

                    case 2:
                        double deposito = LeerMonto("Monto a depositar: ");
                        saldo = Depositar(saldo, deposito);
                        depositos++;
                        MostrarSaldo(saldo);
                        break;

                    case 3:
                        double retiro = LeerMonto("Monto a retirar: ");
                        if (PuedeRetirar(saldo, retiro))
                        {
                            saldo = Retirar(saldo, retiro);
                            retiros++;
                            MostrarSaldo(saldo);
                        }
                        break;

                    case 4:
                        MostrarResumen(saldo, depositos, retiros);
                        break;

                    case 0:
                        Console.WriteLine("Gracias por usar el cajero. Retire su tarjeta.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida, elige entre 0 y 4.");
                        break;
                }
            } while (opcion != 0);
        }

        // pide el PIN hasta 3 veces, devuelve true si lo escribió bien
        static bool ValidarPin()
        {
            for (int intento = 1; intento <= MAX_INTENTOS; intento++)
            {
                int pin = LeerEntero($"Escribe tu PIN (intento {intento} de {MAX_INTENTOS}): ");

                if (pin == PIN_CORRECTO)
                {
                    Console.WriteLine("PIN correcto.");
                    return true;
                }

                int quedan = MAX_INTENTOS - intento;
                if (quedan == 1)
                {
                    Console.WriteLine("PIN incorrecto. Te queda 1 intento.");
                }
                else if (quedan > 1)
                {
                    Console.WriteLine($"PIN incorrecto. Te quedan {quedan} intentos.");
                }
                else
                {
                    Console.WriteLine("PIN incorrecto.");
                }
            }
            return false;
        }

        static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== MENÚ =====");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar");
            Console.WriteLine("3. Retirar");
            Console.WriteLine("4. Resumen de la sesión");
            Console.WriteLine("0. Salir");
        }

        // vuelve a pedir el número hasta que el usuario escriba un entero
        static int LeerEntero(string mensaje)
        {
            int numero;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Eso no es un número entero, intenta otra vez: ");
            }
            return numero;
        }

        // el monto tiene que ser un número mayor que 0
        static double LeerMonto(string mensaje)
        {
            double monto;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out monto) || monto <= 0)
            {
                Console.Write("Monto inválido, tiene que ser mayor que 0: ");
            }
            return monto;
        }

        static double Depositar(double saldo, double monto)
        {
            Console.WriteLine($"Depósito de RD$ {monto:N2} realizado.");
            return saldo + monto;
        }

        // el cajero solo da billetes de 100, no deja pasar del límite ni del saldo
        static bool PuedeRetirar(double saldo, double monto)
        {
            if (monto % 100 != 0)
            {
                Console.WriteLine("El cajero solo entrega múltiplos de RD$ 100.");
                return false;
            }
            else if (monto > LIMITE_RETIRO)
            {
                Console.WriteLine($"El límite por retiro es RD$ {LIMITE_RETIRO:N2}.");
                return false;
            }
            else if (monto > saldo)
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }
            return true;
        }

        static double Retirar(double saldo, double monto)
        {
            Console.WriteLine($"Retiro de RD$ {monto:N2} realizado. Tome su dinero.");
            return saldo - monto;
        }

        static void MostrarSaldo(double saldo)
        {
            Console.WriteLine($"Saldo actual: RD$ {saldo:N2}");
        }

        static void MostrarResumen(double saldo, int depositos, int retiros)
        {
            Console.WriteLine();
            Console.WriteLine("===== RESUMEN =====");
            Console.WriteLine($"Depósitos hechos:  {depositos}");
            Console.WriteLine($"Retiros hechos:    {retiros}");
            Console.WriteLine($"Saldo final:       RD$ {saldo:N2}");
        }
    }
}
