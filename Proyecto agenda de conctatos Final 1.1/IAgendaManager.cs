using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public interface IAgendaManager
    {
        void AgregarContacto(Contacto contacto);
        void EliminarContacto(int indice);
        void EditarContacto(int indice, Contacto contactoEditado);
        List<Contacto> ObtenerContactos();
    }
}