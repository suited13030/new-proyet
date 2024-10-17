using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_agenda_de_conctatos_Final_1._1
{
    public class MenuManager
    {
        private AgendaManager agendaManager;

        public MenuManager(AgendaManager agendaManager)
        {
            this.agendaManager = agendaManager;
        }

        public void ExecuteMainLoop()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    try
                    {
                        switch (opcion)
                        {
                            case 1:
                                AgregarContacto();
                                break;
                            case 2:
                                agendaManager.GuardarContactosEnCSV();
                                MostrarMensaje("\nContactos guardados exitosamente.", ConsoleColor.Green);
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
                                BuscarContactos();
                                break;
                            case 7:
                                salir = true;
                                break;
                            default:
                                MostrarMensaje("Opción no válida.", ConsoleColor.Red);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje($"Error: {ex.Message}", ConsoleColor.Red);
                    }
                }
                else
                {
                    MostrarMensaje("Por favor, ingrese un número válido.", ConsoleColor.Red);
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            }
        }

        private void MostrarMenu()
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
            Console.WriteLine("║ 6. Buscar contactos           ║");
            Console.WriteLine("║ 7. Salir                      ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Seleccione una opción: ");
        }

        private void AgregarContacto()
        {
            Console.Clear();
            MostrarTitulo("Agregar Contacto");

            Contacto nuevoContacto = new Contacto
            {
                Nombre = PedirDato("Nombre"),
                Telefono = PedirDato("Teléfono", ValidadorDatos.ValidarTelefono),
                Correo = PedirDato("Correo", ValidadorDatos.ValidarCorreo),
                FechaHora = PedirFechaHora(),
                Lugar = PedirDato("Lugar"),
                Asunto = PedirDato("Asunto")
            };

            agendaManager.AgregarContacto(nuevoContacto);

            MostrarMensaje("\nContacto agregado exitosamente.", ConsoleColor.Green);
        }

        private void VerContactos()
        {
            Console.Clear();
            MostrarTitulo("Lista de Contactos");

            var contactos = agendaManager.ObtenerContactos();

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
                    Console.WriteLine(contactos[i].ObtenerInformacion());
                    Console.WriteLine();
                }
            }
        }

        private void EliminarContacto()
        {
            Console.Clear();
            MostrarTitulo("Eliminar Contacto");

            if (agendaManager.ContarContactos() == 0)
            {
                MostrarMensaje("No hay contactos en la agenda para eliminar.", ConsoleColor.Yellow);
                return;
            }

            MostrarListaContactos();

            Console.Write("\nIngrese el número del contacto que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= agendaManager.ContarContactos())
            {
                Contacto contactoEliminado = agendaManager.ObtenerContactoPorIndice(indice - 1);
                agendaManager.EliminarContacto(indice - 1);
                MostrarMensaje($"\nContacto '{contactoEliminado.Nombre}' eliminado exitosamente.", ConsoleColor.Green);
            }
            else
            {
                MostrarMensaje("\nNúmero de contacto inválido.", ConsoleColor.Red);
            }
        }

        private void EditarContacto()
        {
            Console.Clear();
            MostrarTitulo("Editar Contacto");

            if (agendaManager.ContarContactos() == 0)
            {
                MostrarMensaje("No hay contactos en la agenda para editar.", ConsoleColor.Yellow);
                return;
            }

            MostrarListaContactos();

            Console.Write("\nIngrese el número del contacto que desea editar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= agendaManager.ContarContactos())
            {
                Contacto contactoAEditar = agendaManager.ObtenerContactoPorIndice(indice - 1);

                Console.WriteLine("\nDeje en blanco si no desea modificar el campo.");

                contactoAEditar.Nombre = PedirDatoOpcional("Nuevo nombre", contactoAEditar.Nombre);
                contactoAEditar.Telefono = PedirDatoOpcional("Nuevo teléfono", contactoAEditar.Telefono, ValidadorDatos.ValidarTelefono);
                contactoAEditar.Correo = PedirDatoOpcional("Nuevo correo", contactoAEditar.Correo, ValidadorDatos.ValidarCorreo);
                contactoAEditar.FechaHora = PedirFechaHoraOpcional("Nueva fecha y hora", contactoAEditar.FechaHora);
                contactoAEditar.Lugar = PedirDatoOpcional("Nuevo lugar", contactoAEditar.Lugar);
                contactoAEditar.Asunto = PedirDatoOpcional("Nuevo asunto", contactoAEditar.Asunto);

                agendaManager.EditarContacto(indice - 1, contactoAEditar);

                MostrarMensaje("\nContacto editado exitosamente.", ConsoleColor.Green);
            }
            else
            {
                MostrarMensaje("\nNúmero de contacto inválido.", ConsoleColor.Red);
            }
        }

        private void BuscarContactos()
        {
            Console.Clear();
            MostrarTitulo("Buscar Contactos");

            Console.Write("Ingrese el criterio de búsqueda: ");
            string criterio = Console.ReadLine();

            var resultados = agendaManager.BuscarContactos(criterio);

            if (resultados.Count == 0)
            {
                MostrarMensaje("No se encontraron contactos que coincidan con el criterio de búsqueda.", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine($"\nSe encontraron {resultados.Count} contactos:");
                for (int i = 0; i < resultados.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"--- Resultado {i + 1} ---");
                    Console.ResetColor();
                    Console.WriteLine(resultados[i].ObtenerInformacion());
                    Console.WriteLine();
                }
            }
        }

        private void MostrarListaContactos()
        {
            var contactos = agendaManager.ObtenerContactos();
            for (int i = 0; i < contactos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contactos[i].Nombre} - {contactos[i].Telefono}");
            }
        }

        private string PedirDato(string campo, Func<string, bool> validacion = null)
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

        private string PedirDatoOpcional(string campo, string valorActual, Func<string, bool> validacion = null)
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

        private DateTime PedirFechaHora()
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

        private DateTime PedirFechaHoraOpcional(string campo, DateTime valorActual)
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

        private void MostrarTitulo(string titulo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== {titulo} ===");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void MostrarMensaje(string mensaje, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}