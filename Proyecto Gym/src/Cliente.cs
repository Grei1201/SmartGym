public class Cliente : Usuario
{
    public Membresia Membresia { get; set; }
    public List<Reserva> Reservas { get; set; }

    public Cliente(int id, string nombre, string correo, string telefono, Membresia membresia)
        : base(id, nombre, correo, telefono)
    {
        Membresia = membresia;
        Reservas = new List<Reserva>();
    }
}
