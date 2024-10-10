using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Interfaces.figuras
{
    internal class Triangulo : figura
    {
        public int Base { get; set; }
        public int Altura { get; set; }

        public Triangulo()
        {
            Nombre = "Triángulo";
        }

        public override void CalculaArea()
        {
            Area = (int)((Base * Altura) / 2.0);
        }

        public override void CalcularPerimetro()
        {
            // Para el perímetro, se necesita el valor de los otros lados.
            // Aquí asumiremos que es un triángulo isósceles.
            double ladoIgual = Math.Sqrt(Math.Pow(Base / 2.0, 2) + Math.Pow(Altura, 2));
            Perimetro = (int)(Base + (2 * ladoIgual));
        }
    }
}
