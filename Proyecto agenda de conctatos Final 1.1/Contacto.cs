using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public class Contacto : ContactoBase
    {
        public DateTime FechaHora { get; set; }
        public string Lugar { get; set; }
        public string Asunto { get; set; }

        public override string ObtenerInformacion()
        {
            return $"Nombre: {Nombre}\n" +
                   $"Teléfono: {Telefono}\n" +
                   $"Correo: {Correo}\n" +
                   $"Fecha y Hora: {FechaHora:dd/MM/yyyy HH:mm}\n" +
                   $"Lugar: {Lugar}\n" +
                   $"Asunto: {Asunto}";
        }

        public string ToCSV()
        {
            return $"{Nombre},{Telefono},{Correo},{FechaHora:dd/MM/yyyy HH:mm},{Lugar},{Asunto}";
        }
    }
}
