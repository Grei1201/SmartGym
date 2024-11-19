public class DatosJson : IDatos
{
    public List<Usuario> CargarUsuarios()
    {
        string json = File.ReadAllText("usuarios.json");
        var usuariosJson = JsonConvert.DeserializeObject<List<dynamic>>(json);

        var usuarios = new List<Usuario>();

        foreach (var item in usuariosJson)
        {
            if (item.Tipo == "Cliente")
            {
                var membresia = new Membresia(item.Membresia.Id, DateTime.Parse(item.Membresia.FechaInicio.ToString()), DateTime.Parse(item.Membresia.FechaFin.ToString()));
                var cliente = new Cliente(item.Id, item.Nombre, item.Correo, item.Telefono, item.Contraseña, membresia);
                usuarios.Add(cliente);
            }
            else if (item.Tipo == "Entrenador")
            {
                var entrenador = new Entrenador(item.Id, item.Nombre, item.Correo, item.Telefono, item.Contraseña, item.Horario, item.PuntosFuertes);
                usuarios.Add(entrenador);
            }
        }

        return usuarios;
    }

    public void GuardarUsuarios(List<Usuario> usuarios)
    {
        string json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
        File.WriteAllText("usuarios.json", json);
    }
}