using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    internal class Persona
    {
        protected int ID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        private DateTime Creado { get; set; }
        public void ImprimeNombre()
        {
            Console.WriteLine(Nombre);
        }
        public void ImprimeID()
        {
            Console.WriteLine(ID);
        }
        public void ImprimeFecha()
        {
            Console.WriteLine(Creado);
        }
        public void CambiarFecha(DateTime nuevaFecha)
        {
            Creado = nuevaFecha;
        }
    }
}
