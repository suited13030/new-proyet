using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public class EstadisticasAgenda
    {
        private AgendaManager agendaManager;

        public EstadisticasAgenda(AgendaManager agendaManager)
        {
            this.agendaManager = agendaManager;
        }

        public int ObtenerTotalContactos()
        {
            return agendaManager.ContarContactos();
        }

        public double ObtenerPromedioContactosPorLetra()
        {
            var contactos = agendaManager.ObtenerContactos();
            var gruposPorLetra = contactos.GroupBy(c => c.Nombre[0].ToString().ToUpper());
            return gruposPorLetra.Average(g => g.Count());
        }

        public string ObtenerLetraMasComun()
        {
            var contactos = agendaManager.ObtenerContactos();
            var gruposPorLetra = contactos.GroupBy(c => c.Nombre[0].ToString().ToUpper());
            return gruposPorLetra.OrderByDescending(g => g.Count()).First().Key;
        }
    }
}