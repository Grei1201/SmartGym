using System.Collections.Generic;

// Esta clase es para: Representar las clases disponibles en el gimnasio.
public class ClaseGimnasio
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Horario { get; set; }
    public int Cupo { get; set; }
    public int EntrenadorId { get; set; }
    public List<Reserva> Reservas { get; set; } = new List<Reserva>();

    // Método para añadir una reserva a la clase, verifica si hay cupos disponibles.
    public bool AñadirReserva(Reserva reserva)
    {
        if (Reservas.Count < Cupo)
        {
            Reservas.Add(reserva);
            return true;
        }
        return false;
    }

    // Método para eliminar una reserva de la clase.
    public void RemoverReserva(Reserva reserva)
    {
        Reservas.Remove(reserva);
    }
}
