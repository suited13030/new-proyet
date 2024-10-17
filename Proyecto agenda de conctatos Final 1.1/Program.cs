using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            AgendaManager agendaManager = new AgendaManager();
            MenuManager menuManager = new MenuManager(agendaManager);
            menuManager.ExecuteMainLoop();
        }
    }
}