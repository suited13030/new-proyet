using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda_new
{
    internal class Articulo
    {
        
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Articulo(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Nombre} - ${Precio}";
        }
    }
}

