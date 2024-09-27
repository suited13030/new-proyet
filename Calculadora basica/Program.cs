using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Calculadora Básica");
            Console.WriteLine("Selecciona una operación:");
            Console.WriteLine("1 - Suma");
            Console.WriteLine("2 - Resta");
            Console.WriteLine("3 - Multiplicación");
            Console.WriteLine("4 - División");
            Console.WriteLine("5 - Salir");

            string opcion = Console.ReadLine();

            if (opcion == "5")
            {
                continuar = false;
                Console.WriteLine("Saliendo de la calculadora...");
                break;
            }

            Console.WriteLine("Ingresa el primer número:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingresa el segundo número:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double resultado = 0;

            switch (opcion)
            {
                case "1":
                    resultado = Suma(num1, num2);
                    Console.WriteLine($"El resultado de la suma es: {resultado}");
                    break;
                case "2":
                    resultado = Resta(num1, num2);
                    Console.WriteLine($"El resultado de la resta es: {resultado}");
                    break;
                case "3":
                    resultado = Multiplicacion(num1, num2);
                    Console.WriteLine($"El resultado de la multiplicación es: {resultado}");
                    break;
                case "4":
                    if (num2 != 0)
                    {
                        resultado = Division(num1, num2);
                        Console.WriteLine($"El resultado de la división es: {resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Error: No se puede dividir entre cero.");
                    }
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, selecciona una operación válida.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static double Suma(double a, double b)
    {
        return a + b;
    }

    static double Resta(double a, double b)
    {
        return a - b;
    }

    static double Multiplicacion(double a, double b)
    {
        return a * b;
    }

    static double Division(double a, double b)
    {
        return a / b;
    }
}
