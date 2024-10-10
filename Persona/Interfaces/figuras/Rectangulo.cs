using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Interfaces.figuras
{
    internal class Rectangulo : figura
    {
        public int Ancho { get; set; }
        public int Alto { get; set; }

        public Rectangulo()
        {
            Nombre = "Rectángulo";
        }

        public override void CalculaArea()
        {
            Area = Ancho * Alto;
        }

        public override void CalcularPerimetro()
        {
            Perimetro = 2 * (Ancho + Alto);
        }
    }
}