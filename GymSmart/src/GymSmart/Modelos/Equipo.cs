using System;

namespace GymManagement
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaFinVidaUtil { get; set; }

        // Método para verificar si el equipo está a menos de 3 meses de su vida útil.
        public bool NecesitaMantenimiento()
        {
            return (FechaFinVidaUtil - DateTime.Now).TotalDays <= 90;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Fecha de Compra: {FechaCompra:yyyy-MM-dd}, Fecha Fin Vida Útil: {FechaFinVidaUtil:yyyy-MM-dd}";
        }
    }
}
