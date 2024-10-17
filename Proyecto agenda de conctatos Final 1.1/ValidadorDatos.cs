using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public class ValidadorDatos
    {
        public static bool ValidarTelefono(string telefono)
        {
            return Regex.IsMatch(telefono, @"^\d{10}$");
        }

        public static bool ValidarCorreo(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        internal bool ValidarContacto(Contacto contacto)
        {
            throw new NotImplementedException();
        }
    }
}