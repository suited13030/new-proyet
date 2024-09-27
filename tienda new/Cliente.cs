using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda_new
{
    internal class Cliente
    {
        
        public string Nombre { get; set; }
        public Carrito Carrito { get; set; }

        public Cliente(string nombre)
        {
            Nombre = nombre;
            Carrito = new Carrito();
        }
    }
}

