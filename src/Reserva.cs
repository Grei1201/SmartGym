// Esta clase es para: Gestionar las reservas de los clientes para las clases y el gimnasio.
public class Reserva
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int ClaseId { get; set; }
    public DateTime FechaReserva { get; set; }
}
