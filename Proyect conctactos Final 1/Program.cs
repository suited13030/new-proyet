using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyect_conctactos_Final_1
{
    internal class Program

    {
        static List<Contacto> contactos = new List<Contacto>();
        static string archivoCSV = "contactos.csv";

        static void Main(string[] args)
        {
            CargarContactosDesdeCSV();

            bool salir = false;

            while (!salir)
            {
                MostrarMenu();

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarContacto();
                            break;
                        case 2:
                            GuardarContactosEnCSV();
                            break;
                        case 3:
                            VerContactos();
                            break;
                        case 4:
                            EliminarContacto();
                            break;
                        case 5:
                            EditarContacto();
                            break;
                        case 6:
                            salir = true;
                            break;
                        default:
                            MostrarMensaje("Opción no válida. Presione cualquier tecla para continuar.", ConsoleColor.Red);
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    MostrarMensaje("Por favor, ingrese un número válido.", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║     Agenda de Contactos       ║");
            Console.WriteLine("╠═══════════════════════════════╣");
            Console.WriteLine("║ 1. Agregar contacto           ║");
            Console.WriteLine("║ 2. Guardar contactos en CSV   ║");
            Console.WriteLine("║ 3. Ver contactos              ║");
            Console.WriteLine("║ 4. Eliminar contacto          ║");
            Console.WriteLine("║ 5. Editar contacto            ║");
            Console.WriteLine("║ 6. Salir                      ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Seleccione una opción: ");
        }

        static void AgregarContacto()
        {
            Console.Clear();
            MostrarTitulo("Agregar Contacto");

            Contacto nuevoContacto = new Contacto
            {
                Nombre = PedirDato("Nombre"),
                Telefono = PedirDato("Teléfono", ValidarTelefono),
                Correo = PedirDato("Correo", ValidarCorreo),
                FechaHora = PedirFechaHora(),
                Lugar = PedirDato("Lugar"),
                Asunto = PedirDato("Asunto")
            };

            contactos.Add(nuevoContacto);

            MostrarMensaje("\nContacto agregado exitosamente. Presione cualquier tecla para continuar.", ConsoleColor.Green);
            Console.ReadKey();
        }

        static void VerContactos()
        {
            Console.Clear();
            MostrarTitulo("Lista de Contactos");

            if (contactos.Count == 0)
            {
                MostrarMensaje("No hay contactos en la agenda.", ConsoleColor.Yellow);
            }
            else
            {
                for (int i = 0; i < contactos.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"--- Contacto {i + 1} ---");
                    Console.ResetColor();
                    Console.WriteLine(contactos[i]);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void GuardarContactosEnCSV()
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
                MostrarMensaje($"\nContactos guardados exitosamente en {archivoCSV}", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                MostrarMensaje($"\nError al guardar los contactos: {ex.Message}", ConsoleColor.Red);
            }

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void CargarContactosDesdeCSV()
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
                                Contacto contacto = new Contacto
                                {
                                    Nombre = datos[0],
                                    Telefono = datos[1],
                                    Correo = datos[2],
                                    FechaHora = DateTime.ParseExact(datos[3], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                                    Lugar = datos[4],
                                    Asunto = datos[5]
                                };
                                contactos.Add(contacto);
                            }
                        }
                    }
                    MostrarMensaje($"Contactos cargados desde {archivoCSV}", ConsoleColor.Green);
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error al cargar los contactos: {ex.Message}", ConsoleColor.Red);
                }
            }
        }

        static void EliminarContacto()
        {
            Console.Clear();
            MostrarTitulo("Eliminar Contacto");

            if (contactos.Count == 0)
            {
                MostrarMensaje("No hay contactos en la agenda para eliminar.", ConsoleColor.Yellow);
            }
            else
            {
                MostrarListaContactos();

                Console.Write("\nIngrese el número del contacto que desea eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= contactos.Count)
                {
                    Contacto contactoEliminado = contactos[indice - 1];
                    contactos.RemoveAt(indice - 1);
                    MostrarMensaje($"\nContacto '{contactoEliminado.Nombre}' eliminado exitosamente.", ConsoleColor.Green);
                }
                else
                {
                    MostrarMensaje("\nNúmero de contacto inválido.", ConsoleColor.Red);
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void EditarContacto()
        {
            Console.Clear();
            MostrarTitulo("Editar Contacto");

            if (contactos.Count == 0)
            {
                MostrarMensaje("No hay contactos en la agenda para editar.", ConsoleColor.Yellow);
            }
            else
            {
                MostrarListaContactos();

                Console.Write("\nIngrese el número del contacto que desea editar: ");
                if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= contactos.Count)
                {
                    Contacto contactoAEditar = contactos[indice - 1];

                    Console.WriteLine("\nDeje en blanco si no desea modificar el campo.");

                    contactoAEditar.Nombre = PedirDatoOpcional("Nuevo nombre", contactoAEditar.Nombre);
                    contactoAEditar.Telefono = PedirDatoOpcional("Nuevo teléfono", contactoAEditar.Telefono, ValidarTelefono);
                    contactoAEditar.Correo = PedirDatoOpcional("Nuevo correo", contactoAEditar.Correo, ValidarCorreo);
                    contactoAEditar.FechaHora = PedirFechaHoraOpcional("Nueva fecha y hora", contactoAEditar.FechaHora);
                    contactoAEditar.Lugar = PedirDatoOpcional("Nuevo lugar", contactoAEditar.Lugar);
                    contactoAEditar.Asunto = PedirDatoOpcional("Nuevo asunto", contactoAEditar.Asunto);

                    MostrarMensaje("\nContacto editado exitosamente.", ConsoleColor.Green);
                }
                else
                {
                    MostrarMensaje("\nNúmero de contacto inválido.", ConsoleColor.Red);
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void MostrarListaContactos()
        {
            for (int i = 0; i < contactos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contactos[i].Nombre} - {contactos[i].Telefono}");
            }
        }

        static string PedirDato(string campo, Func<string, bool> validacion = null)
        {
            while (true)
            {
                Console.Write($"{campo}: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    MostrarMensaje($"El {campo} no puede estar vacío. Intente nuevamente.", ConsoleColor.Red);
                    continue;
                }

                if (validacion == null || validacion(valor))
                {
                    return valor;
                }
                else
                {
                    MostrarMensaje($"El {campo} ingresado no es válido. Intente nuevamente.", ConsoleColor.Red);
                }
            }
        }

        static string PedirDatoOpcional(string campo, string valorActual, Func<string, bool> validacion = null)
        {
            Console.Write($"{campo} (actual: {valorActual}): ");
            string valor = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(valor))
            {
                return valorActual;
            }

            if (validacion == null || validacion(valor))
            {
                return valor;
            }
            else
            {
                MostrarMensaje($"El {campo} ingresado no es válido. Se mantendrá el valor actual.", ConsoleColor.Red);
                return valorActual;
            }
        }

        static bool ValidarTelefono(string telefono)
        {
            return Regex.IsMatch(telefono, @"^\d{10}$");
        }

        static bool ValidarCorreo(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        static DateTime PedirFechaHora()
        {
            while (true)
            {
                Console.Write("Fecha y Hora (DD/MM/YYYY HH:MM): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaHora))
                {
                    return fechaHora;
                }
                else
                {
                    MostrarMensaje("Formato de fecha y hora no válido. Intente nuevamente.", ConsoleColor.Red);
                }
            }
        }

        static DateTime PedirFechaHoraOpcional(string campo, DateTime valorActual)
        {
            Console.Write($"{campo} (actual: {valorActual:dd/MM/yyyy HH:mm}): ");
            string valor = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(valor))
            {
                return valorActual;
            }

            if (DateTime.TryParseExact(valor, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nuevaFechaHora))
            {
                return nuevaFechaHora;
            }
            else
            {
                MostrarMensaje("Formato de fecha y hora no válido. Se mantendrá el valor actual.", ConsoleColor.Red);
                return valorActual;
            }
        }

        static void MostrarTitulo(string titulo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== {titulo} ===");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void MostrarMensaje(string mensaje, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}