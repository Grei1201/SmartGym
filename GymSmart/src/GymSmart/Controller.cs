using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace GymManagement
{
    public static class GymController
    {
        private static readonly string FilePathClientes = "data/clientes.json";
        private static readonly string FilePathClases = "data/clases.json";
        private static readonly string FilePathReservas = "data/reservas.json";
        private static readonly string FilePathEquipos = "data/equipos.json";
        private static string FilePathEntrenadores = "data/entrenadores.json";

       private static List<Cliente> _clientes = new List<Cliente>();
       private static List<Entrenador> _entrenadores = new List<Entrenador>();
       private static List<ClaseGimnasio> _clases = new List<ClaseGimnasio>();
       private static List<Reserva> _reservas = new List<Reserva>();
       private static List<Equipo> _equipos = new List<Equipo>();
        private static int _siguienteIdReserva = 1;

        // Método para cargar datos iniciales de clientes, entrenadores y clases.
        public static void CargarDatos()
        {
            _clientes = LeerClientes(FilePathClientes);
            _entrenadores = LeerEntrenadoresDesdeJson(FilePathEntrenadores);
            _clases = LeerClasesDesdeJson(FilePathClases);
            _reservas = LeerReservasDesdeJson(FilePathReservas);
            _equipos = LeerEquiposDesdeJson(FilePathEquipos);
            AsignarReservasAClases();
    }

        // Método para asignar las reservas cargadas a las clases correspondientes.
        private static void AsignarReservasAClases()
        {
            foreach (var reserva in _reservas)
            {
                var clase = _clases.FirstOrDefault(c => c.Id == reserva.ClaseId);
                if (clase != null)
                {
                    clase.Reservas.Add(reserva);
                }
            }
        }
       // Metodo para registrar un nuevo equipo
        public static void RegistrarEquipo()
        { 
            Console.Clear();
            Console.WriteLine("Registrar nuevo equipo");

            Console.Write("Ingrese el ID del equipo: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) 
            { 
                Console.WriteLine("ID inválido. Operación cancelada.");
                return; 
            } 
            
            Console.Write("Ingrese el nombre del equipo: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la fecha de compra (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaCompra))
            {
                Console.WriteLine("Fecha inválida. Operación cancelada.");
                 return;
            } 
            
            Console.Write("Ingrese la fecha de fin de vida útil (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaFinVidaUtil))
            {
                Console.WriteLine("Fecha inválida. Operación cancelada.");
                return;
            } 
            
            var nuevoEquipo = new Equipo 
            { 
                Id = id,
                Nombre = nombre,
                FechaCompra = fechaCompra,
                FechaFinVidaUtil = fechaFinVidaUtil
            };

            _equipos.Add(nuevoEquipo);
            GuardarEquipos();

            Console.WriteLine($"Equipo '{nombre}' registrado con éxito.");
        }
        // Metodo para verificar alertas de mantenimiento
        public static void VerificarAlertasMantenimiento()
        {
            Console.Clear();
            Console.WriteLine("=== Alertas de Mantenimiento ===");
            
            var equiposNecesitanMantenimiento = _equipos.Where(e => e.NecesitaMantenimiento()).ToList();
            if (equiposNecesitanMantenimiento.Count > 0) 
            { 
                foreach (var equipo in equiposNecesitanMantenimiento)
                { 
                    Console.WriteLine($"Equipo: {equipo.Nombre}, Fecha Fin de Vida Útil: {equipo.FechaFinVidaUtil:yyyy-MM-dd}");
                } 
            }
            else
            {
                Console.WriteLine("No hay equipos que necesiten mantenimiento próximamente.");
            }
        } 
        
        // Método para leer los equipos desde un archivo JSON.
         private static List<Equipo> LeerEquiposDesdeJson(string filePath)
         {
            if (!File.Exists(filePath))
            {
                return new List<Equipo>();
            }
            
             string json = File.ReadAllText(filePath);
             return JsonSerializer.Deserialize<List<Equipo>>(json) ?? new List<Equipo>();
        }

        // Método para guardar los equipos en un archivo JSON.
        private static void GuardarEquipos()
        {
            string json = JsonSerializer.Serialize(_equipos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePathEquipos, json);
        }

        // Método para registrar un nuevo cliente.
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
                FechaInicioMembresia = DateTime.Now,
                FechaFinMembresia = DateTime.Now.AddMonths(1)
            };

            var clientes = LeerClientes(FilePathClientes);
            clientes.Add(nuevoCliente);
            GuardarClientes(clientes);

            Console.WriteLine($"Cliente '{nombre} {apellido}' registrado con éxito.");
        }

        // Método para editar un cliente existente.
        public static void EditarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Editar cliente ===");

            var clientes = LeerClientes(FilePathClientes);
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

        // Método para eliminar un cliente.
        public static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Eliminar cliente ===");

            var clientes = LeerClientes(FilePathClientes);
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

        // Método para notificar el cobro a un cliente.
        public static void NotificarCobro(Cliente cliente)
        {
            var diasRestantes = (cliente.FechaFinMembresia - DateTime.Now).Days;
            if (diasRestantes <= 5)
            {
                Console.WriteLine($"Notificación: La membresía del cliente {cliente.Nombre} {cliente.Apellido} vence en {diasRestantes} días. Por favor, realice el pago.");
            }
        }

        // Método para ver la lista de clientes.
        public static void VerClientes()
        {
            Console.Clear();
            Console.WriteLine("Lista de Clientes ");

            var clientes = LeerClientes(FilePathClientes);

            if (clientes.Count > 0)
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.ToString());
                    NotificarCobro(cliente);
                }
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }

        // Método para gestionar la reserva de una clase por parte de un cliente.
        public static void ReservarClase()
        {
            Console.Clear();
            Console.WriteLine("=== Reservar Clase ===");

            Console.Write("Ingrese el ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int clienteId))
            {
                Console.WriteLine("ID inválido. Operación cancelada.");
                return;
            }

            var cliente = _clientes.FirstOrDefault(c => c.Id == clienteId);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.Write("Ingrese el ID de la clase: ");
            if (!int.TryParse(Console.ReadLine(), out int claseId))
            {
                Console.WriteLine("ID inválido. Operación cancelada.");
                return;
            }

            var clase = _clases.FirstOrDefault(c => c.Id == claseId);
            if (clase == null)
            {
                Console.WriteLine("Clase no encontrada.");
                return;
            }

            var nuevaReserva = new Reserva
            {
                Id = _siguienteIdReserva++,
                ClienteId = clienteId,
                ClaseId = claseId,
                FechaReserva = DateTime.Now
            };

            if (clase.AñadirReserva(nuevaReserva))
            {
                _reservas.Add(nuevaReserva);
                GuardarReservas();
                Console.WriteLine("Reserva realizada con éxito.");
            }
            else
            {
                Console.WriteLine("No hay cupos disponibles para esta clase.");
            }
        }

        // Método para ver las reservas de un cliente específico.
        public static void VerReservasCliente(int clienteId)
        {
            Console.Clear();
            Console.WriteLine($"=== Reservas del Cliente {clienteId} ===");

            var reservasCliente = _reservas.Where(r => r.ClienteId == clienteId).ToList();

            if (reservasCliente.Count > 0)
            {
                foreach (var reserva in reservasCliente)
                {
                    var clase = _clases.FirstOrDefault(c => c.Id == reserva.ClaseId);
                    if (clase != null)
                    {
                        Console.WriteLine($"Reserva ID: {reserva.Id}, Clase: {clase.Nombre}, Horario: {clase.Horario}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay reservas para este cliente.");
            }
        }

                // Método para ver las reservas de las clases asignadas a un entrenador específico.
        public static void VerReservasEntrenador(int entrenadorId)
        {
            Console.Clear();
            Console.WriteLine($"=== Reservas para el Entrenador {entrenadorId} ===");

            var clasesEntrenador = _clases.Where(c => c.EntrenadorId == entrenadorId).ToList();

            if (clasesEntrenador.Count > 0)
            {
                foreach (var clase in clasesEntrenador)
                {
                    Console.WriteLine($"\nClase: {clase.Nombre}, Horario: {clase.Horario}");
                    if (clase.Reservas.Count > 0)
                    {
                        foreach (var reserva in clase.Reservas)
                        {
                            var cliente = _clientes.FirstOrDefault(c => c.Id == reserva.ClienteId);
                            if (cliente != null)
                            {
                                Console.WriteLine($"- Reserva ID: {reserva.Id}, Cliente: {cliente.Nombre} {cliente.Apellido}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay reservas para esta clase.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay clases asignadas a este entrenador.");
            }
        }

        private static List<Entrenador> LeerEntrenadoresDesdeJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Entrenador>();
            }
            
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Entrenador>>(json) ?? new List<Entrenador>();
        }


        // Método para leer las clases desde un archivo JSON.
        private static List<ClaseGimnasio> LeerClasesDesdeJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<ClaseGimnasio>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<ClaseGimnasio>>(json) ?? new List<ClaseGimnasio>();
        }

        // Método para leer las reservas desde un archivo JSON.
        private static List<Reserva> LeerReservasDesdeJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Reserva>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Reserva>>(json) ?? new List<Reserva>();
        }

        // Método para guardar las reservas en un archivo JSON.
        private static void GuardarReservas()
        {
            string json = JsonSerializer.Serialize(_reservas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePathReservas, json);
        }

        // Método para leer los clientes desde un archivo JSON.
        private static List<Cliente> LeerClientes(string filePath)
        {
            if (!File.Exists(FilePathClientes))
            {
                return new List<Cliente>();
            }

            string json = File.ReadAllText(FilePathClientes);
            return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
        }

        // Método para guardar los clientes en un archivo JSON.
        private static void GuardarClientes(List<Cliente> clientes)
        {
            string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePathClientes, json);
        }

        // Metodo para guardar los clientes en un archivo JSON.
        private static void GuardarEntrenadores(List<Entrenador> entrenadores)
{
    string json = JsonSerializer.Serialize(entrenadores, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(FilePathEntrenadores, json);
}
//Metodo para guardaar clases en un archivo JSON.
private static void GuardarClases(List<ClaseGimnasio> clases)
{
    string json = JsonSerializer.Serialize(clases, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(FilePathClases, json);
}

    }
}
