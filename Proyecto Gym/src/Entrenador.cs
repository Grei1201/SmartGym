public class Entrenador : Usuario
{
    public string Horario { get; set; }
    public string PuntosFuertes { get; set; }

    public Entrenador(int id, string nombre, string correo, string telefono, string horario, string puntosFuertes)
        : base(id, nombre, correo, telefono)
    {
        Horario = horario;
        PuntosFuertes = puntosFuertes;
    }
}
