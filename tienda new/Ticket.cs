using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaConsola;

namespace tienda_new
{
    internal class Ticket
    {
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public Ticket(Cliente cliente)
        {
            Cliente = cliente;
            Fecha = DateTime.Now;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine("\n--- Ticket de compra ---");
            Console.WriteLine($"Cliente: {Cliente.Nombre}");
            Console.WriteLine($"Fecha: {Fecha}");
            Cliente.Carrito.MostrarArticulos();
            Console.WriteLine($"Total: ${Cliente.Carrito.CalcularTotal()}");
            Console.WriteLine("-------------------------\n");
        }

    }

}
