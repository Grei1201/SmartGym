public class UsuarioController
{
    private readonly IDatos _datos;
    private readonly Vista _vista;

    public UsuarioController(IDatos datos, Vista vista)
    {
        _datos = datos;
        _vista = vista;
    }

    public void IniciarSesion()
    {
        var (correo, contraseña) = _vista.SolicitarCredenciales();
        try
        {
            var usuarios = _datos.CargarUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.Correo == correo && u.Contraseña == contraseña);

            if (usuario != null)
            {
                if (usuario is Cliente cliente && cliente.Membresia.EstaPorVencer())
                {
                    _vista.MostrarMensaje($"Hola {cliente.Nombre}, tu membresía está por vencer.");
                }
                _vista.MostrarBienvenida(usuario);
            }
            else
            {
                _vista.MostrarMensaje("Correo o contraseña incorrectos.");
            }
        }
        catch (Exception ex)
        {
            _vista.MostrarMensaje($"Error: {ex.Message}");
        }
    }
}
