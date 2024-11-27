using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        string rutaArchivo = @"data/clientes.json"; 

        try
        {
            // Leer el archivo JSON
            string json = File.ReadAllText(rutaArchivo);

            // Deserializar el archivo JSON a una lista de clientes
            List<Cliente> clientes = JsonSerializer.Deserialize<List<Cliente>>(json);

            // Mostrar los datos de los clientes
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.Id}, Nombre: {cliente.Nombre}, Apellido: {cliente.Apellido}, Edad: {cliente.Edad}, Membresía Activa: {cliente.MembresiaActiva}, Fecha Inicio: {cliente.FechaInicioMembresia}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
        }
    }
}
public class Entrenador
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public List<string> PuntosFuertes { get; set; }
    public List<string> Horarios { get; set; }

    // Ruta de archivo JSON
    private static string rutaArchivo = @"data/entrenadores.json";

    // Cargar entrenadores desde JSON
    public static List<Entrenador> CargarDatos()
    {
        if (!File.Exists(rutaArchivo))
        {
            return new List<Entrenador>();
        }

        var json = File.ReadAllText(rutaArchivo);
        return JsonSerializer.Deserialize<List<Entrenador>>(json) ?? new List<Entrenador>();
    }

    // Guardar entrenadores en el archivo JSON
    public static void GuardarDatos(List<Entrenador> entrenadores)
    {
        var json = JsonSerializer.Serialize(entrenadores, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(rutaArchivo, json);
    }
}


public class Membresia
{
    public string TipoMembresia { get; set; }
    public double Monto { get; set; }
    public string Descripcion { get; set; }

    // Ruta de archivo JSON
    private static string rutaArchivo = @"data/membresias.json";

    // Cargar membresías desde JSON
    public static List<Membresia> CargarDatos()
    {
        if (!File.Exists(rutaArchivo))
        {
            return new List<Membresia>();
        }

        var json = File.ReadAllText(rutaArchivo);
        return JsonSerializer.Deserialize<List<Membresia>>(json) ?? new List<Membresia>();
    }

    // Guardar membresías en el archivo JSON
    public static void GuardarDatos(List<Membresia> membresias)
    {
        var json = JsonSerializer.Serialize(membresias, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(rutaArchivo, json);
    }
}

