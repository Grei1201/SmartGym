using System;
using System.Collections.Generic;



public class ClienteController
{
    private List<Cliente> clientes;
    private MembresiaController membresiaController;

    public ClienteController()
    {
        // Inicializar el modelo y cargar los clientes
        clientes = Cliente.CargarDatos();

        // Inicializar el controlador de membresías
        membresiaController = new MembresiaController();
    }

    // Obtener todos los clientes
    public List<Cliente> ObtenerClientes()
    {
        return clientes;
    }

    // Agregar un nuevo cliente
    public void AgregarCliente(Cliente nuevoCliente)
    {
        clientes.Add(nuevoCliente);
        Cliente.GuardarDatos(clientes);
    }

    // Eliminar un cliente por ID
    public void EliminarCliente(int id)
    {
        var cliente = clientes.Find(c => c.Id == id);
        if (cliente != null)
        {
            clientes.Remove(cliente);
            Cliente.GuardarDatos(clientes);
        }
    }

    // Asignar una membresía a un cliente
    public void AsignarMembresia(int clienteId, string tipoMembresia)
    {
        var cliente = clientes.Find(c => c.Id == clienteId);
        if (cliente != null)
        {
            var membresia = membresiaController.BuscarPorTipo(tipoMembresia);
            if (membresia != null)
            {
                cliente.MembresiaActiva = true;
                cliente.FechaInicioMembresia = DateTime.Now;
                Cliente.GuardarDatos(clientes);
                Console.WriteLine($"Membresía '{tipoMembresia}' asignada al cliente {cliente.Nombre} {cliente.Apellido}.");
            }
            else
            {
                Console.WriteLine($"No se encontró la membresía del tipo: {tipoMembresia}");
            }
        }
        else
        {
            Console.WriteLine($"No se encontró al cliente con ID: {clienteId}");
        }
    }
}

public class EntrenadorController
{
    private List<Entrenador> entrenadores;

    public EntrenadorController()
    {
        // Inicializar el modelo y cargar los entrenadores
        entrenadores = Entrenador.CargarDatos();
    }

    // Obtener todos los entrenadores
    public List<Entrenador> ObtenerEntrenadores()
    {
        return entrenadores;
    }

    // Agregar un nuevo entrenador
    public void AgregarEntrenador(Entrenador nuevoEntrenador)
    {
        entrenadores.Add(nuevoEntrenador);
        Entrenador.GuardarDatos(entrenadores);
    }

    // Eliminar un entrenador por ID
    public void EliminarEntrenador(int id)
    {
        var entrenador = entrenadores.Find(e => e.Id == id);
        if (entrenador != null)
        {
            entrenadores.Remove(entrenador);
            Entrenador.GuardarDatos(entrenadores);
        }
    }

    // Buscar entrenadores por especialidad
    public List<Entrenador> BuscarPorEspecialidad(string especialidad)
    {
        return entrenadores.FindAll(e => e.PuntosFuertes.Contains(especialidad));
    }
}

public class MembresiaController
{
    private List<Membresia> membresias;

    public MembresiaController()
    {
        // Inicializar el modelo y cargar las membresías
        membresias = Membresia.CargarDatos();
    }

    // Obtener todas las membresías
    public List<Membresia> ObtenerMembresias()
    {
        return membresias;
    }

    // Agregar una nueva membresía
    public void AgregarMembresia(Membresia nuevaMembresia)
    {
        membresias.Add(nuevaMembresia);
        Membresia.GuardarDatos(membresias);
    }

    // Buscar membresías por tipo
    public Membresia BuscarPorTipo(string tipoMembresia)
    {
        return membresias.Find(m => m.TipoMembresia.Equals(tipoMembresia, StringComparison.OrdinalIgnoreCase));
    }
}

