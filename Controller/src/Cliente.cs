// Esta clase es para: Representar a los clientes del gimnasio.
using System;

namespace GymManagement
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public bool MembresiaActiva { get; set; }
        public DateTime FechaInicioMembresia { get; set; }
        public DateTime FechaFinMembresia { get; set; }

        // Constructor que establece el rol del cliente.
        public Cliente()
        {
            Rol = "Cliente"
        }

// Método para obtener una cadena de texto con la información del cliente.
        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre} {Apellido}, Edad: {Edad}, " +
                   $"Membresía Activa: {MembresiaActiva}, Fecha Inicio: {FechaInicioMembresia:yyyy-MM-dd}, Fecha Fin: {FechaFinMembresia:yyyy-MM-dd}";
        }
    }
}
