using System;

namespace AgendaTelefonica.Utils
{
    /// <summary>
    /// Utilidades para manejo de consola
    /// </summary>
    public static class ConsoleUtils
    {
        public static void MostrarEncabezado(string titulo)
        {
            Console.Clear();
            Console.WriteLine(new string('═', 50));
            Console.WriteLine($"         {titulo}");
            Console.WriteLine(new string('═', 50));
            Console.WriteLine();
        }

        public static void MostrarMensaje(string mensaje, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        public static void MostrarError(string mensaje)
        {
            MostrarMensaje($"❌ ERROR: {mensaje}", ConsoleColor.Red);
        }

        public static void MostrarExito(string mensaje)
        {
            MostrarMensaje($"✅ {mensaje}", ConsoleColor.Green);
        }

        public static void MostrarInformacion(string mensaje)
        {
            MostrarMensaje($"ℹ️  {mensaje}", ConsoleColor.Cyan);
        }

        public static void Pausar()
        {
            Console.WriteLine("\n⏎ Presione Enter para continuar...");
            Console.ReadLine();
        }

        public static string LeerTexto(string prompt, bool requerido = false)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine()?.Trim() ?? "";

            while (requerido && string.IsNullOrEmpty(input))
            {
                MostrarError("Este campo es requerido");
                Console.Write($"{prompt}: ");
                input = Console.ReadLine()?.Trim() ?? "";
            }

            return input;
        }

        public static void MostrarMenuPrincipal()
        {
            Console.WriteLine("\n📱 MENÚ PRINCIPAL");
            Console.WriteLine(new string('─', 30));
            Console.WriteLine("1. 📖 Ver todos los contactos");
            Console.WriteLine("2. ➕ Agregar nuevo contacto");
            Console.WriteLine("3. 🔍 Buscar contacto");
            Console.WriteLine("4. 🗑️  Eliminar contacto");
            Console.WriteLine("5. 📊 Ver estadísticas");
            Console.WriteLine("6. 📝 Análisis de estructuras");
            Console.WriteLine("7. ℹ️  Información del proyecto");
            Console.WriteLine("8. ❌ Salir");
            Console.WriteLine(new string('─', 30));
            Console.Write("Seleccione una opción (1-8): ");
        }
    }
}