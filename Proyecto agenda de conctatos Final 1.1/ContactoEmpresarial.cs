using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public class ContactoEmpresarial : ContactoBase
    {
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }

        public override string ObtenerInformacion()
        {
            return $"Nombre: {Nombre}\n" +
                   $"Teléfono: {Telefono}\n" +
                   $"Correo: {Correo}\n" +
                   $"Empresa: {Empresa}\n" +
                   $"Cargo: {Cargo}\n" +
                   $"Departamento: {Departamento}";
        }
    }
}