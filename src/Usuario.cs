public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }

    public Usuario(int id, string nombre, string correo, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Correo = correo;
        Telefono = telefono;
    }
}
