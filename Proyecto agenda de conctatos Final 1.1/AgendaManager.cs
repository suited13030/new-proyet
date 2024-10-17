using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public class AgendaManager : IAgendaManager
    {
        private List<Contacto> contactos;
        private string archivoCSV;
        private ValidadorDatos validador;

        public AgendaManager()
        {
            contactos = new List<Contacto>();
            archivoCSV = "contactos.csv";
            validador = new ValidadorDatos(); // Suponiendo que lo usarás para validar más adelante.
            CargarContactosDesdeCSV();
        }

        public void AgregarContacto(Contacto contacto)
        {
            // Validaciones antes de agregar el contacto
            if (!validador.ValidarContacto(contacto))
            {
                throw new ArgumentException("Los datos del contacto no son válidos.");
            }

            contactos.Add(contacto);
        }

        public void EliminarContacto(int indice)
        {
            if (indice >= 0 && indice < contactos.Count)
            {
                contactos.RemoveAt(indice);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(indice), "Índice de contacto no válido.");
            }
        }

        public void EditarContacto(int indice, Contacto contactoEditado)
        {
            if (indice >= 0 && indice < contactos.Count)
            {
                if (!validador.ValidarContacto(contactoEditado))
                {
                    throw new ArgumentException("Los datos del contacto editado no son válidos.");
                }

                contactos[indice] = contactoEditado;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(indice), "Índice de contacto no válido.");
            }
        }

        public List<Contacto> ObtenerContactos()
        {
            return new List<Contacto>(contactos); // Devolver una copia de la lista para evitar modificaciones externas.
        }

        public void GuardarContactosEnCSV()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivoCSV))
                {
                    sw.WriteLine("Nombre,Teléfono,Correo,Fecha y Hora,Lugar,Asunto");
                    foreach (var contacto in contactos)
                    {
                        sw.WriteLine(contacto.ToCSV());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error al guardar los contactos: {ex.Message}", ex);
            }
        }

        private void CargarContactosDesdeCSV()
        {
            if (File.Exists(archivoCSV))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(archivoCSV))
                    {
                        sr.ReadLine(); // Saltar la línea de encabezado
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] datos = linea.Split(',');
                            if (datos.Length == 6)
                            {
                                // Parseo y validación de fecha
                                if (DateTime.TryParseExact(datos[3], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaHora))
                                {
                                    Contacto contacto = new Contacto
                                    {
                                        Nombre = datos[0],
                                        Telefono = datos[1],
                                        Correo = datos[2],
                                        FechaHora = fechaHora,
                                        Lugar = datos[4],
                                        Asunto = datos[5]
                                    };
                                    contactos.Add(contacto);
                                }
                                else
                                {
                                    throw new FormatException($"Formato de fecha no válido en el archivo CSV para el contacto: {datos[0]}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new IOException($"Error al cargar los contactos: {ex.Message}", ex);
                }
            }
        }

        public List<Contacto> BuscarContactos(string criterio)
        {
            return contactos.Where(c =>
                (c.Nombre.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (c.Telefono.Contains(criterio)) ||
                (c.Correo.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();
        }
        public int ContarContactos()
        {
            return contactos.Count;
        }

        public Contacto ObtenerContactoPorIndice(int indice)
        {
            if (indice >= 0 && indice < contactos.Count)
            {
                return contactos[indice];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(indice), "Índice de contacto no válido.");
            }
        }
    }
}