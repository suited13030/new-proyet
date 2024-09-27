using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaConsola;

namespace tienda_new
{
    internal class Carrito
    {
        public List<Articulo> Articulos { get; set; }

        public Carrito()
        {
            Articulos = new List<Articulo>();
        }

        public void AgregarArticulo(Articulo articulo)
        {
            Articulos.Add(articulo);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var articulo in Articulos)
            {
                total += articulo.Precio;
            }
            return total;
        }

        public void MostrarArticulos()
        {
            Console.WriteLine("Artículos en el carrito:");
            foreach (var articulo in Articulos)
            {
                Console.WriteLine(articulo);
            }
        }
    }
}

