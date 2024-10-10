using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Interfaces.figuras
{
    internal abstract class figura
    {
        protected int Area { get; set; }
        protected int Perimetro { get; set; }
        public string UnidadMedida { get; set; }
        public string Nombre { get; protected set; }

        public abstract void CalculaArea();
        public abstract void CalcularPerimetro();

        public void MuestraArea()
        {
            Console.WriteLine($"El área de {Nombre} es {Area} {UnidadMedida}^2");
        }

        public void MuestraPerimetro()
        {
            Console.WriteLine($"El perímetro de {Nombre} es {Perimetro} {UnidadMedida}");
        }
    }
}
