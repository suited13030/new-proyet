using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda_new
{
    using System;
    using System.Collections.Generic;

    namespace TiendaConsola
    {
        // Clase Articulo
        class Articulo
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

        // Clase Cliente
        class Cliente
        {
            public string Nombre { get; set; }
            public Carrito Carrito { get; set; }

            public Cliente(string nombre)
            {
                Nombre = nombre;
                Carrito = new Carrito();
            }
        }

        // Clase Carrito
        class Carrito
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

        // Clase Caja
        class Caja
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

        // Clase Ticket
        class Ticket
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

        // Clase Catalogo
        class Catalogo
        {
            public List<Articulo> Articulos { get; set; }

            public Catalogo()
            {
                Articulos = new List<Articulo>()
            {
                new Articulo("Tomate", 10.00m),
                new Articulo("Limon", 20.00m),
                new Articulo("Carne", 50.00m),
                new Articulo("Pechuga", 150.00m),
                new Articulo("Audifonos", 200.00m)
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

        // Clase Programa Principal
        class Program
        {
            static void Main(string[] args)
            {
                Catalogo catalogo = new Catalogo();
                Cliente cliente = new Cliente("Juan");
                Caja caja = new Caja();

                bool continuarComprando = true;

                while (continuarComprando)
                {
                    catalogo.MostrarArticulos();

                    Console.WriteLine("\nSeleccione el número del artículo que desea agregar al carrito:");
                    int seleccion = int.Parse(Console.ReadLine()) - 1;

                    Articulo articuloSeleccionado = catalogo.SeleccionarArticulo(seleccion);
                    if (articuloSeleccionado != null)
                    {
                        cliente.Carrito.AgregarArticulo(articuloSeleccionado);
                        Console.WriteLine($"{articuloSeleccionado.Nombre} agregado al carrito.");
                    }
                    else
                    {
                        Console.WriteLine("Selección no válida. Intente nuevamente.");
                    }

                    Console.WriteLine("¿Desea seguir comprando? (s/n):");
                    string respuesta = Console.ReadLine();
                    continuarComprando = respuesta.ToLower() == "s";
                }

                // Procesar el pago
                caja.ProcesarPago(cliente);

                Console.WriteLine("Gracias por su compra. ¡Hasta luego!");
            }
        }
    }
}
