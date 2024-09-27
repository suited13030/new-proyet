using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaConsola;

namespace tienda_new
{
    internal class caja
    {
        public void ProcesarPago(Cliente cliente)
        {
            decimal total = cliente.Carrito.CalcularTotal();
            Console.WriteLine($"\nProcesando pago para {cliente.Nombre}...");
            Console.WriteLine($"Total a pagar: ${total}");
            Console.WriteLine("Pago realizado con éxito.");
            GenerarTicket(cliente);
        }

        private void GenerarTicket(Cliente cliente)
        {
            Ticket ticket = new Ticket(cliente);
            ticket.MostrarDetalles();
        }



    }
}
