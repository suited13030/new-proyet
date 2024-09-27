using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numero_mayor_de_una_lista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion;
            do
            {
                // Crear una lista de números
                List<int> numeros = new List<int>();

                // Pedir al usuario cuántos números quiere ingresar
                int cantidad = 0;
                bool esNumeroValido = false;
                while (!esNumeroValido)
                {
                    Console.WriteLine("¿Cuántos números quieres ingresar?");
                    if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
                    {
                        esNumeroValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingrese un número válido mayor que 0.");
                    }
                }

                // Leer los números ingresados por el usuario
                for (int i = 0; i < cantidad; i++)
                {
                    int numero = 0;
                    bool esNumeroCorrecto = false;
                    while (!esNumeroCorrecto)
                    {
                        Console.Write($"Introduce el número {i + 1}: ");
                        if (int.TryParse(Console.ReadLine(), out numero))
                        {
                            numeros.Add(numero);
                            esNumeroCorrecto = true;
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                        }
                    }
                }

                // Encontrar el número mayor en la lista
                int numeroMayor = EncontrarNumeroMayor(numeros);

                // Mostrar el número mayor
                Console.WriteLine($"El número mayor es: {numeroMayor}");

                // Preguntar si el usuario quiere continuar
                Console.WriteLine("\n¿Desea ingresar otra lista de números? (s/n)");
                opcion = Console.ReadLine().ToLower();

            } while (opcion == "s");

            Console.WriteLine("Gracias por usar el programa. ¡Adiós!");
        }

        // Método para encontrar el número mayor en una lista
        static int EncontrarNumeroMayor(List<int> numeros)
        {
            int mayor = numeros[0]; // Asumimos que el primer número es el mayor

            // Iterar a través de la lista y encontrar el número mayor
            foreach (int numero in numeros)
            {
                if (numero > mayor)
                {
                    mayor = numero;
                }
            }

            return mayor;
        }
    }
}
