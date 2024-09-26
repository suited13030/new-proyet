using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOSemana1Console
{
    internal class Program
    {


     
    static void Main(string[] args)
        {
            string oper;
            do
            {
                MostrarMenu();
                oper = Console.ReadLine();

                switch (oper)
                {
                    case "1":
                        ProcesarNumeros();
                        break;
                    case "2":
                        ProcesarPrimos();
                        break;
                    case "3":
                        ImprimirNumeroMayor();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (oper != "4")
                {
                    PausarAntesDeVolverAlMenu();
                }

            } while (oper != "4"); // Repite el ciclo hasta que el usuario elija salir
        }

        // Mostrar el menú principal
        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la operación que quiere usar:");
            Console.WriteLine("1. Número mayor o menor");
            Console.WriteLine("2. Números primos");
            Console.WriteLine("3. Imprimir solo el número mayor");
            Console.WriteLine("4. Salir");
        }

        // Pausar antes de volver al menú
        private static void PausarAntesDeVolverAlMenu()
        {
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // Procesar la entrada de números y determinar mayor y menor
        private static void ProcesarNumeros()
        {
            int[] numeros = LeerNumeros(3);
            MostrarMayor(numeros);
            MostrarMenor(numeros);
        }

        // Leer una cantidad específica de números ingresados por el usuario
        private static int[] LeerNumeros(int cantidad)
        {
            int[] numeros = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Dame el número {i + 1}:");
                numeros[i] = Convert.ToInt32(Console.ReadLine());
            }
            return numeros;
        }

        // Mostrar el número mayor de una lista de números
        private static void MostrarMayor(int[] numeros)
        {
            Console.WriteLine($"El número mayor es: {numeros.Max()}");
        }

        // Mostrar el número menor de una lista de números
        private static void MostrarMenor(int[] numeros)
        {
            Console.WriteLine($"El número menor es: {numeros.Min()}");
        }

        // Pedir al usuario una cantidad de números y mostrar solo el mayor
        private static void ImprimirNumeroMayor()
        {
            Console.WriteLine("¿Cuántos números quieres ingresar?");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            int[] numeros = LeerNumeros(cantidad);
            MostrarMayor(numeros);
        }

        // Procesar el cálculo de números primos
        private static void ProcesarPrimos()
        {
            Console.WriteLine("Dame un número:");
            int N = Convert.ToInt32(Console.ReadLine());
            MostrarNumerosPrimos(N);
        }

        // Mostrar todos los números primos entre 1 y N
        private static void MostrarNumerosPrimos(int N)
        {
            Console.WriteLine($"Números primos de 1 a {N}:");

            for (int i = 2; i <= N; i++)
            {
                if (EsPrimo(i))
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine(); // Salto de línea después de imprimir los números primos
        }

        // Determinar si un número es primo
        private static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;
            if (numero == 2) return true;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }
    }
}
