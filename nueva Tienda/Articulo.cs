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
    public int Cantidad { get; set; } = 1;

    // Método para calcular el subtotal según la cantidad
    public decimal CalcularSubtotal()
    {
        return Precio * Cantidad;
    }

    // Método para clonar un artículo con la cantidad especificada
    public Articulo Copiar()
    {
        return new Articulo
        {
            ID = this.ID,
            Nombre = this.Nombre,
            Precio = this.Precio,
            Cantidad = this.Cantidad
        };
    }
}