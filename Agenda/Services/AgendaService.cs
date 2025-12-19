using System;
using System.Collections.Generic;
using System.Linq;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de la agenda telefónica
    /// Demuestra el uso de List<T> como estructura de datos principal
    /// </summary>
    public class AgendaService
    {
        // Lista de contactos - Estructura de datos principal
        private List<Contacto> contactos;

        public AgendaService()
        {
            contactos = new List<Contacto>();
            CargarContactosEjemplo();
        }

        /// <summary>
        /// Agrega un nuevo contacto a la agenda
        /// </summary>
        public bool AgregarContacto(string nombre, string telefono, string email = "", string direccion = "")
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new ArgumentException("El nombre es requerido");
                
                if (string.IsNullOrWhiteSpace(telefono))
                    throw new ArgumentException("El teléfono es requerido");

                // Crear y agregar el contacto
                Contacto nuevoContacto = new Contacto(nombre, telefono, email, direccion);
                contactos.Add(nuevoContacto);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los contactos
        /// </summary>
        public List<Contacto> ObtenerTodosContactos()
        {
            return new List<Contacto>(contactos); // Retorna copia para proteger datos
        }

        /// <summary>
        /// Busca contactos por criterio
        /// </summary>
        public List<Contacto> BuscarContactos(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
                return new List<Contacto>();

            return contactos.Where(c => c.ContieneTexto(criterio)).ToList();
        }

        /// <summary>
        /// Elimina un contacto por su índice
        /// </summary>
        public bool EliminarContacto(int indice)
        {
            if (indice >= 0 && indice < contactos.Count)
            {
                contactos.RemoveAt(indice);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Obtiene estadísticas de la agenda
        /// </summary>
        public Dictionary<string, int> ObtenerEstadisticas()
        {
            return new Dictionary<string, int>
            {
                { "TotalContactos", contactos.Count },
                { "ConEmail", contactos.Count(c => !string.IsNullOrEmpty(c.Email)) },
                { "ConDireccion", contactos.Count(c => !string.IsNullOrEmpty(c.Direccion)) }
            };
        }

        /// <summary>
        /// Carga contactos de ejemplo para demostración
        /// </summary>
        private void CargarContactosEjemplo()
        {
            contactos.Add(new Contacto("Juan Pérez", "0981234567", "juan.perez@email.com", "Av. Amazonas 123"));
            contactos.Add(new Contacto("María García", "0998765432", "maria.garcia@empresa.com", "Calle 10 de Agosto"));
            contactos.Add(new Contacto("Carlos López", "0971122334", "", "Barrio Centro"));
            contactos.Add(new Contacto("Ana Martínez", "0964455667", "ana.m@universidad.edu.ec", ""));
        }

        /// <summary>
        /// Obtiene la cantidad total de contactos
        /// </summary>
        public int ObtenerCantidadContactos()
        {
            return contactos.Count;
        }
    }
}