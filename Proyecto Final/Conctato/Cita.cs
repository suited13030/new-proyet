using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Conctato
{
    internal class Cita
    {
        public int ID_Cita { get; set; }
        public DateTime FechaHora { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Lugar { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public int ID_Contacto { get; set; } // Relacionado con Contacto
        public object Dur { get; private set; }

        DatabaseConnection db = new DatabaseConnection();

        // Método para programar una cita
        public void ProgramarCita()
        {
            using (SqlConnection connection = db.Conectar())
            {
                string query = "INSERT INTO Citas (ID_Contacto, FechaHora, Duracion, Lugar, Asunto, Descripcion) " +
                               "VALUES (@ID_Contacto, @FechaHora, @Duracion, @Lugar, @Asunto, @Descripcion)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID_Contacto", ID_Contacto);
                cmd.Parameters.AddWithValue("@FechaHora", FechaHora);
                cmd.Parameters.AddWithValue("@Duracion", Duracion);
                cmd.Parameters.AddWithValue("@Lugar", Lugar);
                cmd.Parameters.AddWithValue("@Asunto", Asunto);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para editar una cita
        public void EditarCita()
        {
            using (SqlConnection connection = db.Conectar())
            {
                string query = "UPDATE Citas SET FechaHora = @FechaHora, Duracion = @Duracion, Lugar = @Lugar, Asunto = @Asunto, Descripcion = @Descripcion " +
                               "WHERE ID_Cita = @ID_Cita";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID_Cita", ID_Cita);
                cmd.Parameters.AddWithValue("@FechaHora", FechaHora);
                cmd.Parameters.AddWithValue("@Duracion", Dur);
            }
        }
    }
}
