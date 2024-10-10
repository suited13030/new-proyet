using Persona.Interfaces.figuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Cuadrado------");
            Cuadrado cuadrado = new Cuadrado()
            {
                MedidaLado = 5,
                UnidadMedida = "metros"
            };
            cuadrado.CalculaArea();
            cuadrado.CalcularPerimetro();
            cuadrado.MuestraArea();
            cuadrado.MuestraPerimetro();

            Console.WriteLine("------Rectangulo------");
            Rectangulo rectangulo = new Rectangulo()
            {
                Ancho = 5,
                Alto = 10,
                UnidadMedida = "metros"
            };
            rectangulo.CalculaArea();
            rectangulo.CalcularPerimetro();
            rectangulo.MuestraArea();
            rectangulo.MuestraPerimetro();

            Console.WriteLine("------Triangulo------");
            Triangulo triangulo = new Triangulo()
            {
                Base = 6,
                Altura = 8,
                UnidadMedida = "metros"
            };
            triangulo.CalculaArea();
            triangulo.CalcularPerimetro();
            triangulo.MuestraArea();
            triangulo.MuestraPerimetro();

            Console.WriteLine("------Circulo------");
            Circulo circulo = new Circulo()
            {
                Radio = 5,
                UnidadMedida = "metros"
            };
            circulo.CalculaArea();
            circulo.CalcularPerimetro();
            circulo.MuestraArea();
            circulo.MuestraPerimetro();

            Console.WriteLine("------Poligono------");
            Poligono poligono = new Poligono()
            {
                LongitudLado = 6,
                UnidadMedida = "metros"
            };
            poligono.CalculaArea();
            poligono.CalcularPerimetro();
            poligono.MuestraArea();
            poligono.MuestraPerimetro();


            Console.ReadLine();
        }
    }
}

    

