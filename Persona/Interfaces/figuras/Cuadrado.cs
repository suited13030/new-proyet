using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Interfaces.figuras
{
    internal class Cuadrado : figura
    {
        public int MedidaLado { get; set; }

        public Cuadrado()
        {
            Nombre = "Cuadrado";
        }

        public override void CalculaArea()
        {
            Area = MedidaLado * MedidaLado;
        }

        public override void CalcularPerimetro()
        {
            Perimetro = MedidaLado * 4;
        }
    }
}