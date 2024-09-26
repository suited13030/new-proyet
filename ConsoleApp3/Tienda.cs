using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tienda
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

    internal class Carrito
    {
        public List<Producto> Lista { get; set; } = new List<Producto>();

        // Método para agregar producto al carrito
        public void AgregarProducto(Producto producto)
        {
            Lista.Add(producto);
        }

        // Método para mostrar el carrito con los productos agregados
        public void MostrarCarrito()
        {
            Console.WriteLine("\n--- Productos en el Carrito ---");
            foreach (var producto in Lista)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, " +
                                  $"Cantidad: {producto.Cantidad}, " +
                                  $"Precio: {producto.Precio:C}, " +
                                  $"Total: {producto.Cantidad * producto.Precio:C}");
            }
        }

        // Método para calcular el total del carrito
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var producto in Lista)
            {
                total += producto.Precio * producto.Cantidad;
            }
            return total;
        }
    }

    internal class Caja
    {
        // Método para cobrar el total del carrito y calcular el cambio
        public void Cobrar(Carrito carrito)
        {
            decimal total = carrito.CalcularTotal();
            Console.WriteLine($"\nEl total a pagar es: {total:C}");

            Console.WriteLine("Ingrese la cantidad pagada:");
            decimal pago = Convert.ToDecimal(Console.ReadLine());

            if (pago >= total)
            {
                decimal cambio = pago - total;
                Console.WriteLine($"Pago recibido. Su cambio es: {cambio:C}");
            }
            else
            {
                Console.WriteLine("Pago insuficiente. Intente nuevamente.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Carrito carrito = new Carrito();
            bool agregarProductos = true;

            // Ciclo para agregar productos al carrito
            while (agregarProductos)
            {
                Console.WriteLine("Ingrese el nombre del producto:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la cantidad:");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el precio:");
                decimal precio = Convert.ToDecimal(Console.ReadLine());

                // Crear un nuevo producto y agregarlo al carrito
                Producto producto = new Producto()
                {
                    Nombre = nombre,
                    Cantidad = cantidad,
                    Precio = precio
                };
                carrito.AgregarProducto(producto);

                Console.WriteLine("¿Desea agregar otro producto? (S/N):");
                string respuesta = Console.ReadLine().ToUpper();
                agregarProductos = (respuesta == "S");
            }

            // Mostrar los productos del carrito
            carrito.MostrarCarrito();

            // Crear una instancia de la caja y proceder a cobrar
            Caja caja = new Caja();
            caja.Cobrar(carrito);
        }
    }
}

