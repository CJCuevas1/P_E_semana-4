using System;

namespace AgendaTelefonica.Models
{
    /// <summary>
    /// Representa un contacto en la agenda telefónica
    /// Clase que demuestra el uso de tipos de datos y encapsulamiento
    /// </summary>
    public class Contacto
    {
        // Propiedades públicas
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        // Constructor
        public Contacto(string nombre, string telefono, string email = "", string direccion = "")
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }

        // Método para mostrar información del contacto
        public void MostrarInformacion(int numero = 0)
        {
            if (numero > 0)
                Console.Write($"[{numero}] ");
            
            Console.WriteLine($"👤 {Nombre}");
            Console.WriteLine($"   📱 Teléfono: {Telefono}");
            
            if (!string.IsNullOrEmpty(Email))
                Console.WriteLine($"   📧 Email: {Email}");
            
            if (!string.IsNullOrEmpty(Direccion))
                Console.WriteLine($"   📍 Dirección: {Direccion}");
            
            Console.WriteLine(new string('─', 40));
        }

        // Método para búsqueda rápida
        public bool ContieneTexto(string texto)
        {
            texto = texto.ToLower();
            return Nombre.ToLower().Contains(texto) || 
                   Telefono.Contains(texto) ||
                   Email.ToLower().Contains(texto);
        }
    }
}