using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    internal class persona2 : Persona
    {
        public persona2(string nombre, string email, int id)
        {
            Nombre = nombre;
            Email = Email;
            ID = id;
            ImprimeID();
            ImprimeNombre();
            ImprimeEmail();
        }
           
            public void ImprimeEmail()
            {
                Console.WriteLine(Email);
            }
        }

    }

