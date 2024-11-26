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

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre} {Apellido}, Edad: {Edad}, " +
                   $"Membresía Activa: {MembresiaActiva}, Fecha Inicio: {FechaInicioMembresia:yyyy-MM-dd}";
        }
    }
}
