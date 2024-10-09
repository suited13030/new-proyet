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
            persona2 persona2 = new persona2("juan","juan@correo.com",1);
            Console.ReadLine();
                persona2.Nombre = " juan luis";
            persona2.Email = "juan@correo.com";
            persona2.ImprimeNombre();
            persona2.ImprimeEmail();
            persona2.CambiarFecha(DateTime.Now);
            persona2.ImprimeFecha();
            Console.ReadLine(); 
        }
    }
}
