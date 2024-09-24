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
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Que desea hacer?");
                Console.WriteLine("0- Salir");
                Console.WriteLine("1- Validar numeros primos");
                Console.WriteLine("2- Numero mayor y menor de 3 numeros");
                Console.WriteLine("3- Numero mayor de una lista");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 0:
                        continuar = false;
                        break;
                    case 1:
                        NumerosPirmos();
                        break;
                    case 2:
                        NumeroMayorNUmeroMenor();
                        break;
                    case 3:
                        MayorDeUnaLista();
                        break;
                }
                if (continuar)
                {
                    Console.WriteLine("Desea realizar otra operacion?");
                    Console.WriteLine("S- SI");
                    Console.WriteLine("N- NO");
                    continuar = char.ToUpper(Console.ReadKey().KeyChar) == 'S';
                    Console.Clear();
                }
            }
            Console.ReadLine();
        }

        //Tarea:
        //Resolver el problema de los numero primos
        //El codigo debe de mostrar cuales son los numero primos de 1 hasta el numero indicado
        //ejemplo:
        //dado el numero 7
        //debe de mostrar que el numero 2,3, 5 y 7 son primos
        private static void NumerosPirmos()
        {
            int n = 0;
            Console.WriteLine("Dame un numero mayor a 1");
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 2)
            {
                Console.WriteLine("Numero no valido");
            }
            for (int i = 2; i <= n; i++)
            {
                if (IsPrimo(i))
                {
                    Console.WriteLine($"{i} es primo");
                }
            }
            Console.WriteLine();
        }

        private static bool IsPrimo(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void NumeroMayorNUmeroMenor()
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            Console.WriteLine("Dame el primer numero");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el segundo numero");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el tercer numero");
            num3 = Convert.ToInt32(Console.ReadLine());
            NumeroMayor(num1, num2, num3);
            NumeroMenor(num1, num2, num3);
        }
        private static void NumeroMayor(int num1, int num2, int num3)
        {
            if (num1 > num2)
            {
                if (num1 > num3)
                {
                    Console.WriteLine($"el numero {num1} es el mayor");
                }
                else
                {
                    Console.WriteLine("el tercer numero es el mayor");
                }

            }
            else if (num2 > num1)
            {
                if (num2 > num3)
                {
                    Console.WriteLine("el segundo numero es el mayor");
                }
                else
                {
                    Console.WriteLine("el tercer numero es el mayor");
                }
            }

        }

        private static void NumeroMenor(int num1, int num2, int num3)
        {
            if (num1 < num2)
            {
                if (num1 < num3)
                {
                    Console.WriteLine("el perimer numero es el menor");
                }
                else
                {
                    Console.WriteLine("el tercer numero es el menor");
                }

            }
            else if (num2 < num1)
            {
                if (num2 < num3)
                {
                    Console.WriteLine("el segundo numero es el menor");
                }
                else
                {
                    Console.WriteLine("el tercer numero es el menor");
                }
            }
        }

        private static void MayorDeUnaLista()
        {
            bool continuar = true;
            List<int> lista = new List<int>();
            while (continuar)
            {
                Console.WriteLine("Escribe un numero");
                int numero = Convert.ToInt32(Console.ReadLine());
                lista.Add(numero);
                Console.WriteLine("Preguntar si quiere agregar otro numero");
                Console.WriteLine("S- SI");
                Console.WriteLine("N- No");
                continuar = char.ToUpper(Console.ReadKey().KeyChar) == 'S';
                Console.Clear();
            }
            bool esMayor = false;
            for (int i = 0; i < lista.Count; i++)//FOR 1
            {
                int N = lista[i];//obtener numero de la lista 
                for (int j = 0; j < lista.Count; j++)//FOR 2
                {
                    int M = lista[j];//obtener numero del segundo for
                    if (N < M)
                    {
                        break;
                    }
                    else if (N == M || N > M)
                    {
                        if (j == lista.Count - 1)
                        {
                            esMayor = true;
                        }
                    }
                }
                //si aun no se ha encontrado el mayor,
                //pasa a la siguiente iteracion del for 1
                if (!esMayor)
                {
                    break;
                }
            }
            Console.WriteLine("El numero mayor es:");
        }
    }
}
