using System;
using AgendaTelefonica.Services;
using AgendaTelefonica.Utils;

namespace AgendaTelefonica
{
    /// <summary>
    /// PROGRAMA PRINCIPAL - AGENDA TELEFÓNICA
    /// Práctica #01: Identificación de tipos de datos
    /// Estructura de Datos - Universidad Estatal Amazónica
    /// </summary>
    class Program
    {
        static AgendaService agendaService = new AgendaService();
        static ReporteService reporteService = new ReporteService();

        static void Main(string[] args)
        {
            MostrarInformacionInicial();

            bool continuar = true;
            while (continuar)
            {
                ConsoleUtils.MostrarEncabezado("AGENDA TELEFÓNICA - UEA");
                ConsoleUtils.MostrarMenuPrincipal();

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        MostrarTodosContactos();
                        break;

                    case "2":
                        AgregarContacto();
                        break;

                    case "3":
                        BuscarContactos();
                        break;

                    case "4":
                        EliminarContacto();
                        break;

                    case "5":
                        MostrarEstadisticas();
                        break;

                    case "6":
                        MostrarAnalisisEstructuras();
                        break;

                    case "7":
                        MostrarInformacionProyecto();
                        break;

                    case "8":
                        MostrarReportePorInicial(); 
                        break;

                    case "9":
                        continuar = false; 
                        break;

                    default:
                        ConsoleUtils.MostrarError("Opción no válida.");
                        break;
                }

                if (continuar)
                {
                    ConsoleUtils.Pausar();
                }
            }

            MostrarMensajeDespedida();
        }

        // =========================
        // INFORMACIÓN INICIAL
        // =========================
        static void MostrarInformacionInicial()
        {
            ConsoleUtils.MostrarEncabezado("PRÁCTICA #01 - ESTRUCTURA DE DATOS");
            ConsoleUtils.MostrarInformacion("🤖 Agente de IA utilizado: ChatGPT");
            ConsoleUtils.MostrarInformacion("📊 Porcentaje de código con IA: 40%");
            ConsoleUtils.Pausar();
        }

        // =========================
        // CONTACTOS
        // =========================
        static void MostrarTodosContactos()
        {
            ConsoleUtils.MostrarEncabezado("LISTA DE CONTACTOS");

            var contactos = agendaService.ObtenerTodosContactos();

            if (contactos.Count == 0)
            {
                ConsoleUtils.MostrarInformacion("No hay contactos registrados.");
                return;
            }

            for (int i = 0; i < contactos.Count; i++)
            {
                contactos[i].MostrarInformacion(i + 1);
            }
        }

        static void AgregarContacto()
        {
            ConsoleUtils.MostrarEncabezado("AGREGAR CONTACTO");

            string nombre = ConsoleUtils.LeerTexto("Nombre", true);
            string telefono = ConsoleUtils.LeerTexto("Teléfono", true);
            string email = ConsoleUtils.LeerTexto("Email (opcional)");
            string direccion = ConsoleUtils.LeerTexto("Dirección (opcional)");

            bool agregado = agendaService.AgregarContacto(nombre, telefono, email, direccion);

            if (agregado)
                ConsoleUtils.MostrarExito("Contacto agregado correctamente.");
            else
                ConsoleUtils.MostrarError("No se pudo agregar el contacto.");
        }

        static void BuscarContactos()
        {
            ConsoleUtils.MostrarEncabezado("BUSCAR CONTACTOS");

            string criterio = ConsoleUtils.LeerTexto("Ingrese criterio de búsqueda", true);
            var resultados = agendaService.BuscarContactos(criterio);

            if (resultados.Count == 0)
            {
                ConsoleUtils.MostrarInformacion("No se encontraron coincidencias.");
                return;
            }

            for (int i = 0; i < resultados.Count; i++)
            {
                resultados[i].MostrarInformacion(i + 1);
            }
        }

        static void EliminarContacto()
        {
            ConsoleUtils.MostrarEncabezado("ELIMINAR CONTACTO");

            var contactos = agendaService.ObtenerTodosContactos();

            if (contactos.Count == 0)
            {
                ConsoleUtils.MostrarInformacion("No hay contactos para eliminar.");
                return;
            }

            for (int i = 0; i < contactos.Count; i++)
            {
                contactos[i].MostrarInformacion(i + 1);
            }

            Console.Write("\nIngrese el número del contacto a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int indice) &&
                indice >= 1 && indice <= contactos.Count &&
                agendaService.EliminarContacto(indice - 1))
            {
                ConsoleUtils.MostrarExito("Contacto eliminado exitosamente.");
            }
            else
            {
                ConsoleUtils.MostrarError("Operación inválida.");
            }
        }

        // =========================
        // REPORTERÍA
        // =========================
        static void MostrarEstadisticas()
        {
            ConsoleUtils.MostrarEncabezado("ESTADÍSTICAS");

            var e = agendaService.ObtenerEstadisticas();

            Console.WriteLine($"• Total de contactos: {e["TotalContactos"]}");
            Console.WriteLine($"• Contactos con email: {e["ConEmail"]}");
            Console.WriteLine($"• Contactos con dirección: {e["ConDireccion"]}");
        }

        static void MostrarReportePorInicial()
        {
            ConsoleUtils.MostrarEncabezado("REPORTE POR INICIAL DEL NOMBRE (VECTOR)");

            var contactos = agendaService.ObtenerTodosContactos();

            if (contactos.Count == 0)
            {
                ConsoleUtils.MostrarInformacion("No hay contactos registrados.");
                return;
            }

            // 👉 USO EXPLÍCITO DE VECTOR (ARRAY)
            reporteService.ReportePorInicial(contactos);
        }

        // =========================
        // ANÁLISIS
        // =========================
        static void MostrarAnalisisEstructuras()
        {
            ConsoleUtils.MostrarEncabezado("ANÁLISIS DE ESTRUCTURAS DE DATOS");
            reporteService.AnalisisEstructuras();
        }

        // =========================
        // INFORMACIÓN GENERAL
        // =========================
        static void MostrarInformacionProyecto()
        {
            ConsoleUtils.MostrarEncabezado("INFORMACIÓN DEL PROYECTO");

            Console.WriteLine("Asignatura: Estructura de Datos");
            Console.WriteLine("Práctica: #01 - Identificación de tipos de datos");
            Console.WriteLine("Institución: Universidad Estatal Amazónica");
            Console.WriteLine("Período académico: 2025-2026");
            Console.WriteLine("Lenguaje: C# (.NET)");
        }

        static void MostrarMensajeDespedida()
        {
            ConsoleUtils.MostrarEncabezado("FIN DEL PROGRAMA");
            ConsoleUtils.MostrarExito("Práctica #01 completada correctamente.");
            ConsoleUtils.Pausar();
        }
    }
}
