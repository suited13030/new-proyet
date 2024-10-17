using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public abstract class ContactoBase : IContacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public abstract string ObtenerInformacion();
    }
}