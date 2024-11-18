public class UsuarioController
{
    private readonly IDatos _datos;

    public UsuarioController(IDatos datos)
    {
        _datos = datos;
    }

    public Usuario IniciarSesion(string correo, string contraseña)
    {
        var usuarios = _datos.CargarUsuarios();
        var usuario = usuarios.FirstOrDefault(u => u.Correo == correo && u.Contraseña == contraseña);
        
        if (usuario != null)
        {
            if (usuario is Cliente cliente && cliente.Membresia.EstaPorVencer())
            {
                NotificarMembresia(cliente);
            }
            return usuario;
        }
        throw new Exception("Correo o contraseña incorrectos.");
    }

    private void NotificarMembresia(Cliente cliente)
    {
        // Implementar lógica de notificación de membresía
        Console.WriteLine($"Hola {cliente.Nombre}, tu membresía está por vencer.");
    }
}
