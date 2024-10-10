using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Interfaces.figuras
{
    internal class Poligono : figura
    {
        public double LongitudLado { get; set; }

        public Poligono()
        {
            Nombre = "Polígono Regular";
        }

        public override void CalculaArea()
        {
            // Asumiremos que es un pentágono regular.
            Area = (int)((1.0 / 4) * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * Math.Pow(LongitudLado, 2));
        }

        public override void CalcularPerimetro()
        {
            // Perímetro: número de lados * longitud del lado (asumiendo 5 lados).
            Perimetro = (int)(5 * LongitudLado);
        }
    }
}