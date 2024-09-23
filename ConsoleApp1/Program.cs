using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un número: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"Los números primos de 1 hasta {n} son:");

            for (int i = 2; i <= n; i++)
            {
                if (EsPrimo(i))
                {
                    Console.Write(i);

                    // Si no es el último número, mostramos el guion "-" entre los números primos.
                    if (i != n && SiguientePrimo(i, n))
                    {
                        Console.Write("-");
                    }
                }
            }

            Console.WriteLine(); // Para dejar un salto de línea al final
        }

        // Función que verifica si un número es primo
        static bool EsPrimo(int num)
        {
            if (num < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Función que busca si existe un número primo después del actual
        static bool SiguientePrimo(int actual, int limite)
        {
            for (int i = actual + 1; i <= limite; i++)
            {
                if (EsPrimo(i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}