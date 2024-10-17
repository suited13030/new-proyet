using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public class ContactoFamiliar : ContactoBase
    {
        public string Relacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DireccionFamiliar { get; set; }

        public override string ObtenerInformacion()
        {
            return $"Nombre: {Nombre}\n" +
                   $"Teléfono: {Telefono}\n" +
                   $"Correo: {Correo}\n" +
                   $"Relación: {Relacion}\n" +
                   $"Fecha de Nacimiento: {FechaNacimiento:dd/MM/yyyy}\n" +
                   $"Dirección Familiar: {DireccionFamiliar}";
        }
    }
}