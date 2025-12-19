using System;
using System.Collections.Generic;
using System.Linq;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Services
{
    public class ReporteService
    {
        // ============================
        // REPORTE GENERAL DE CONTACTOS
        // ============================
        public void MostrarTodosContactos(List<Contacto> contactos)
        {
            if (contactos.Count == 0)
            {
                Console.WriteLine("No existen contactos registrados.");
                return;
            }

            Console.WriteLine("LISTADO GENERAL DE CONTACTOS");
            Console.WriteLine("----------------------------------");

            foreach (var contacto in contactos)
            {
                Console.WriteLine($"Nombre: {contacto.Nombre}");
                Console.WriteLine($"Teléfono: {contacto.Telefono}");
                Console.WriteLine($"Email: {contacto.Email}");
                Console.WriteLine("----------------------------------");
            }
        }

        // ============================
        // BÚSQUEDA DE CONTACTOS
        // ============================
        public void BuscarContacto(List<Contacto> contactos, string criterio)
        {
            var resultados = contactos
                .Where(c => c.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron contactos con ese criterio.");
                return;
            }

            Console.WriteLine("RESULTADOS DE BÚSQUEDA");
            Console.WriteLine("----------------------------------");

            foreach (var contacto in resultados)
            {
                Console.WriteLine($"Nombre: {contacto.Nombre}");
                Console.WriteLine($"Teléfono: {contacto.Telefono}");
                Console.WriteLine($"Email: {contacto.Email}");
                Console.WriteLine("----------------------------------");
            }
        }

        // ============================
        // ESTADÍSTICAS GENERALES
        // ============================
        public void MostrarEstadisticas(List<Contacto> contactos)
        {
            Console.WriteLine("ESTADÍSTICAS DE LA AGENDA");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Total de contactos: {contactos.Count}");

            var dominios = contactos
                .Where(c => c.Email.Contains("@"))
                .GroupBy(c => c.Email.Split('@')[1])
                .Select(g => new { Dominio = g.Key, Cantidad = g.Count() });

            foreach (var dominio in dominios)
            {
                Console.WriteLine($"Dominio {dominio.Dominio}: {dominio.Cantidad} contactos");
            }
        }

        // ==================================================
        // REPORTE POR INICIAL DEL NOMBRE (USO DE VECTOR)
        // ==================================================
        public void ReportePorInicial(List<Contacto> contactos)
        {
            // VECTOR (ARRAY UNIDIMENSIONAL)
            int[] contadorIniciales = new int[26];

            foreach (var contacto in contactos)
            {
                if (!string.IsNullOrEmpty(contacto.Nombre))
                {
                    char inicial = char.ToUpper(contacto.Nombre[0]);

                    if (inicial >= 'A' && inicial <= 'Z')
                    {
                        int indice = inicial - 'A';
                        contadorIniciales[indice]++;
                    }
                }
            }

            Console.WriteLine("REPORTE DE CONTACTOS POR INICIAL");
            Console.WriteLine("----------------------------------");

            for (int i = 0; i < contadorIniciales.Length; i++)
            {
                if (contadorIniciales[i] > 0)
                {
                    Console.WriteLine($"{(char)('A' + i)} : {contadorIniciales[i]} contactos");
                }
            }
        }

        // ==================================================
        // ANÁLISIS DE ESTRUCTURAS UTILIZADAS
        // ==================================================
        public void AnalisisEstructuras()
        {
            Console.WriteLine("ANÁLISIS DE ESTRUCTURAS DE DATOS UTILIZADAS");
            Console.WriteLine("----------------------------------");

            Console.WriteLine("1. List<Contacto>");
            Console.WriteLine("Ventajas:");
            Console.WriteLine("- Tamaño dinámico.");
            Console.WriteLine("- Fácil inserción y eliminación.");
            Console.WriteLine("Desventajas:");
            Console.WriteLine("- Búsquedas lineales en grandes volúmenes.");

            Console.WriteLine();

            Console.WriteLine("2. Vector (array int[])");
            Console.WriteLine("Ventajas:");
            Console.WriteLine("- Acceso directo por índice.");
            Console.WriteLine("- Uso eficiente de memoria.");
            Console.WriteLine("Desventajas:");
            Console.WriteLine("- Tamaño fijo.");
            Console.WriteLine("- Menor flexibilidad que las listas.");

            Console.WriteLine();

            Console.WriteLine("3. Programación Orientada a Objetos");
            Console.WriteLine("Ventajas:");
            Console.WriteLine("- Organización del código.");
            Console.WriteLine("- Reutilización y mantenibilidad.");
            Console.WriteLine("Desventajas:");
            Console.WriteLine("- Mayor complejidad inicial.");
        }
    }
}
