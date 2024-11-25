public class Vista
{
    public void MostrarMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public void MostrarBienvenida(Usuario usuario)
    {
        Console.WriteLine($"Bienvenido, {usuario.Nombre}!");
    }

    public (string Correo, string Contraseña) SolicitarCredenciales()
    {
        Console.Write("Correo: ");
        var correo = Console.ReadLine();
        Console.Write("Contraseña: ");
        var contraseña = Console.ReadLine();
        return (correo, contraseña);
    }
}
