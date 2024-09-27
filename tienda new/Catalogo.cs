using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaConsola;

namespace tienda_new
{
    internal class Catalogo
    {
        public List<Articulo> Articulos { get; set; }

        public Catalogo()
        {
            Articulos = new List<Articulo>()
            {
                new Articulo("Laptop", 1000.00m),
                new Articulo("Mouse", 20.00m),
                new Articulo("Teclado", 50.00m),
                new Articulo("Monitor", 150.00m),
                new Articulo("Impresora", 200.00m)
            };
        }

        public void MostrarArticulos()
        {
            Console.WriteLine("\n--- Catálogo de Artículos ---");
            for (int i = 0; i < Articulos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Articulos[i]}");
            }
            Console.WriteLine("-----------------------------");
        }

        public Articulo SeleccionarArticulo(int indice)
        {
            if (indice >= 0 && indice < Articulos.Count)
            {
                return Articulos[indice];
            }
            return null;
        }
    }
}

