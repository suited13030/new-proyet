using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static int contadorCompras = 1;  // Contador de compras, empieza en 1

    static void Main(string[] args)
    {
        Catalogo.LlenarCatalogo();

        while (true)
        {
            Carrito carrito = new Carrito();
            Ticket ticket = new Ticket();

            // Ciclo para agregar artículos al carrito
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
            decimal iva = Math.Round(totalSinIVA * 0.16m, 2); // 16% de IVA

            decimal totalConIVA = totalSinIVA + iva;
            Console.WriteLine($"\nTotal a pagar (sin IVA): {totalSinIVA:C2}");
            Console.WriteLine($"IVA (16%): {iva:C2}");
            Console.WriteLine($"Total a pagar (con IVA): {totalConIVA:C2}");

            // Solicitar el monto pagado
            Console.WriteLine("Ingrese el monto con el que va a pagar:");
            decimal montoPagado;
            while (!decimal.TryParse(Console.ReadLine(), out montoPagado) || montoPagado < totalConIVA)
            {
                Console.WriteLine("El monto pagado es insuficiente. Ingrese un monto mayor o igual al total.");
            }

            decimal cambio = Math.Round(montoPagado - totalConIVA, 2);

            // Llenar detalles del ticket
            ticket.Lista = carrito.ObtenerArticulos();
            ticket.Total = totalSinIVA;
            ticket.IVA = iva;
            ticket.Pagado = montoPagado;
            ticket.Cambio = cambio;
            ticket.Fecha = DateTime.Now;
            ticket.NumCompra = contadorCompras++;  // Incrementar el número de compra

            // Mostrar el ticket completo
            ticket.MostrarTicket();

            // Preguntar si el usuario desea realizar otra compra
            Console.WriteLine("¿Desea realizar otra compra? (S/N)");
            string respuesta = Console.ReadLine()?.ToUpper();
            if (respuesta != "S")
            {
                break;  // Salir del ciclo y terminar el programa
            }
        }

        Console.WriteLine("Gracias por su compra.");
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();  // Pausa hasta que el usuario presione una tecla
    }
}
