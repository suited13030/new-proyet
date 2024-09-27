using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






    internal class Articulo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; } = 1;  // Se añade una propiedad de cantidad, con valor inicial de 1

        // Método para calcular el subtotal según la cantidad
        public decimal CalcularSubtotal()
        {
            return Precio * Cantidad;
        }
    }

    internal class Catalogo
    {
        private static List<Articulo> Inventario { get; set; }

        public static void LlenarCatalogo()
        {
            Inventario = new List<Articulo>
            {
                new Articulo {Nombre = "Jabón", Precio = 18.9m, ID = 1},
                new Articulo {Nombre = "Mayonesa", Precio = 20.6m, ID = 2},
                new Articulo {Nombre = "Tomate", Precio = 10.9m, ID = 3},
                new Articulo {Nombre = "Carne", Precio = 19.8m, ID = 4},
                new Articulo {Nombre = "Huevos", Precio = 30m, ID = 5},
            };
        }

        public static void MostrarCatalogo()
        {
            Console.WriteLine("\n--- Catálogo de Productos ---");
            foreach (Articulo art in Inventario)
            {
                Console.WriteLine($"{art.ID} - {art.Nombre} - Precio: {art.Precio:C}");
            }
        }

        public static Articulo BuscarArticuloPorID(int artID)
        {
            return Inventario.Find(articulo => articulo.ID == artID);
        }
    }

    internal class Carrito
    {
        private List<Articulo> articulosEnCarrito = new List<Articulo>();

        public void AgregarArticulo(Articulo articulo)
        {
            // Verificar si el artículo ya existe en el carrito para aumentar la cantidad
            var articuloExistente = articulosEnCarrito.Find(a => a.ID == articulo.ID);
            if (articuloExistente != null)
            {
                articuloExistente.Cantidad++;  // Aumentar la cantidad si el artículo ya estaba en el carrito
            }
            else
            {
                articulosEnCarrito.Add(articulo);
            }
        }

        public List<Articulo> ObtenerArticulos()
        {
            return articulosEnCarrito;
        }

        public void MostrarArticulosEnCarrito()
        {
            Console.WriteLine("\n--- Artículos en el Carrito ---");
            if (articulosEnCarrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                foreach (var articulo in articulosEnCarrito)
                {
                    Console.WriteLine($"ID: {articulo.ID}, Nombre: {articulo.Nombre}, Cantidad: {articulo.Cantidad}, Precio Unitario: {articulo.Precio:C}, Subtotal: {articulo.CalcularSubtotal():C}");
                }
            }
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var articulo in articulosEnCarrito)
            {
                total += articulo.CalcularSubtotal();  // Calcular el total basado en el subtotal de cada artículo
            }
            return total;
        }
    }

    internal class Ticket
    {
        public List<Articulo> Lista { get; set; } = new List<Articulo>();
        public decimal Total { get; set; }
        public decimal Pagado { get; set; }
        public decimal Cambio { get; set; }
        public DateTime Fecha { get; set; }
        public int NumCompra { get; set; }
        public decimal IVA { get; set; }

        public void MostrarTicket()
        {
            Console.WriteLine("\n----- TICKET DE COMPRA -----");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Número de Compra: {NumCompra}");
            Console.WriteLine("\n--- Detalle de los Artículos Comprados ---");

            foreach (var articulo in Lista)
            {
                Console.WriteLine($"- {articulo.Nombre}: Cantidad: {articulo.Cantidad}, Precio Unitario: {articulo.Precio:C}, Subtotal: {articulo.CalcularSubtotal():C}");
            }

            Console.WriteLine("\n--- Resumen de la Compra ---");
            Console.WriteLine($"Total (sin IVA): {Total:C}");
            Console.WriteLine($"IVA (16%): {IVA:C}");
            Console.WriteLine($"Total (con IVA): {(Total + IVA):C}");
            Console.WriteLine($"Pagado: {Pagado:C}");
            Console.WriteLine($"Cambio: {Cambio:C}");
            Console.WriteLine("-----------------------------");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Llenar el catálogo con productos
            Catalogo.LlenarCatalogo();

            Carrito carrito = new Carrito();
            Ticket ticket = new Ticket();

            while (true)
            {
                Console.WriteLine("\nSelecciona el artículo (ingresa '0' para finalizar):");
                Catalogo.MostrarCatalogo();

                if (!int.TryParse(Console.ReadLine(), out int artID))
                {
                    Console.WriteLine("Por favor ingresa un número válido.");
                    continue;
                }

                if (artID == 0) break;

                Articulo articuloSeleccionado = Catalogo.BuscarArticuloPorID(artID);

                if (articuloSeleccionado != null)
                {
                    carrito.AgregarArticulo(articuloSeleccionado);
                    Console.WriteLine($"Artículo '{articuloSeleccionado.Nombre}' agregado al carrito.");
                }
                else
                {
                    Console.WriteLine("Artículo no encontrado.");
                }
            }

            // Mostrar los artículos en el carrito
            carrito.MostrarArticulosEnCarrito();

            // Calcular total y generar ticket
            decimal totalSinIVA = carrito.CalcularTotal();
            decimal iva = totalSinIVA * 0.16m; // 16% de IVA

            Console.WriteLine($"\nTotal a pagar (sin IVA): {totalSinIVA:C}");
            Console.WriteLine($"IVA (16%): {iva:C}");
            decimal totalConIVA = totalSinIVA + iva;
            Console.WriteLine($"Total a pagar (con IVA): {totalConIVA:C}");

            // Solicitar el monto pagado
            Console.WriteLine("Ingrese el monto con el que va a pagar:");
            decimal montoPagado;
            while (!decimal.TryParse(Console.ReadLine(), out montoPagado) || montoPagado < totalConIVA)
            {
                Console.WriteLine("El monto pagado es insuficiente. Ingrese un monto mayor o igual al total.");
            }

            decimal cambio = montoPagado - totalConIVA;

            // Llenar detalles del ticket
            ticket.Lista = carrito.ObtenerArticulos();
            ticket.Total = totalSinIVA;
            ticket.IVA = iva;
            ticket.Pagado = montoPagado;
            ticket.Cambio = cambio;
            ticket.Fecha = DateTime.Now;
            ticket.NumCompra = new Random().Next(1000, 9999); // Generar un número de compra aleatorio

            // Mostrar el ticket completo
            ticket.MostrarTicket();

            Console.WriteLine("Gracias por su compra.");

            // Pausar la ejecución para evitar que el programa se cierre inmediatamente
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();  // Pausa hasta que el usuario presione una tecla
        }
    }
