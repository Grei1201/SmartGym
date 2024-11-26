using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GymManagement
{
    public static class GymController
    {
        private static readonly string FilePath = "clientes.json";

        public static void RegistrarCliente()
        {
            Console.Clear();
            Console.WriteLine("Registrar nuevo cliente");

            Console.Write("Ingrese el ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Operación cancelada.");
                return;
            }

            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido del cliente: ");
            string apellido = Console.ReadLine();

            Console.Write("Ingrese la edad del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Edad inválida. Operación cancelada.");
                return;
            }

            Console.Write("¿La membresía está activa? (s/n): ");
            bool membresiaActiva = Console.ReadLine()?.ToLower() == "s";

            var nuevoCliente = new Cliente
            {
                Id = id,
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                MembresiaActiva = membresiaActiva,
                FechaInicioMembresia = DateTime.Now
            };

            var clientes = LeerClientes();
            clientes.Add(nuevoCliente);
            GuardarClientes(clientes);

            Console.WriteLine($"Cliente '{nombre} {apellido}' registrado con éxito.");
        }
        public static void EditarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Editar cliente ===");

            var clientes = LeerClientes();
            Console.Write("Ingrese el ID del cliente que desea editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Operación cancelada.");
                return;
            }

            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine($"Cliente encontrado: {cliente}");
            Console.Write("Ingrese el nuevo nombre (dejar vacío para mantener): ");
            string nuevoNombre = Console.ReadLine();
            Console.Write("Ingrese el nuevo apellido (dejar vacío para mantener): ");
            string nuevoApellido = Console.ReadLine();
            Console.Write("Ingrese la nueva edad (dejar vacío para mantener): ");
            string nuevaEdad = Console.ReadLine();
            Console.Write("¿La membresía está activa? (s/n, dejar vacío para mantener): ");
            string nuevaMembresiaActiva = Console.ReadLine();

            if (!string.IsNullOrEmpty(nuevoNombre)) cliente.Nombre = nuevoNombre;
            if (!string.IsNullOrEmpty(nuevoApellido)) cliente.Apellido = nuevoApellido;
            if (int.TryParse(nuevaEdad, out int edad)) cliente.Edad = edad;
            if (!string.IsNullOrEmpty(nuevaMembresiaActiva))
            {
                cliente.MembresiaActiva = nuevaMembresiaActiva.ToLower() == "s";
            }

            GuardarClientes(clientes);
            Console.WriteLine("Cliente actualizado con éxito.");
        }

        public static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Eliminar cliente ===");

            var clientes = LeerClientes();
            Console.Write("Ingrese el ID del cliente que desea eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Operación cancelada.");
                return;
            }

            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            clientes.Remove(cliente);
            GuardarClientes(clientes);
            Console.WriteLine($"Cliente '{cliente.Nombre} {cliente.Apellido}' eliminado con éxito.");
        }

        public static void VerClientes()
        {
            Console.Clear();
            Console.WriteLine("Lista de Clientes ");

            var clientes = LeerClientes();

            if (clientes.Count > 0)
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.ToString());
                }
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }

        private static List<Cliente> LeerClientes()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Cliente>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
        }

        private static void GuardarClientes(List<Cliente> clientes)
        {
            string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
