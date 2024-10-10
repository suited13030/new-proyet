using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Interfaces.figuras
{
    internal class Circulo : figura
    {
        public int Radio { get; set; }

        public Circulo()
        {
            Nombre = "Círculo";
        }

        public override void CalculaArea()
        {
            Area = (int)(Math.PI * Radio * Radio);
        }

        public override void CalcularPerimetro()
        {
            Perimetro = (int)(2 * Math.PI * Radio);
        }
    }
}