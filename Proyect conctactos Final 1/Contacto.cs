using System;

namespace Proyect_conctactos_Final_1
{
    internal class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaHora { get; set; }
        public string Lugar { get; set; }
        public string Asunto { get; set; }

        public override string ToString()
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