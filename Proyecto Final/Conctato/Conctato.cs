using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Conctato
{
    internal class Conctato
    {
        public int ID_Contacto { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        DatabaseConnection db = new DatabaseConnection();

        // Método para agregar un contacto
        public void AgregarContacto()
        {
            using (SqlConnection connection = db.Conectar())
            {
                string query = "INSERT INTO Contactos (Nombre, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para editar un contacto
        public void EditarContacto()
        {
            using (SqlConnection connection = db.Conectar())
            {
                string query = "UPDATE Contactos SET Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE ID_Contacto = @ID_Contacto";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID_Contacto", ID_Contacto);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para eliminar un contacto
        public void EliminarContacto()
        {
            using (SqlConnection connection = db.Conectar())
            {
                string query = "DELETE FROM Contactos WHERE ID_Contacto = @ID_Contacto";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID_Contacto", ID_Contacto);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para buscar un contacto
        public void BuscarContacto(string nombre)
        {
            using (SqlConnection connection = db.Conectar())
            {
                string query = "SELECT * FROM Contactos WHERE Nombre LIKE @Nombre";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID_Contacto"]}, Nombre: {reader["Nombre"]}, Teléfono: {reader["Telefono"]}, Correo: {reader["Correo"]}");
                }
            }
        }
    }
}

