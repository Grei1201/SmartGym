class Program
{
    static void Main(string[] args)
    {
        IDatos datos = new DatosJson();
        var usuarioController = new UsuarioController(datos);

        try
        {
            var usuario = usuarioController.IniciarSesion("cliente1@ejemplo.com", "password123");
            Console.WriteLine($"Bienvenido {usuario.Nombre}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
