using System;
using System.Collections.Generic;

namespace GymManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cargar los datos al controlador
            GymController.CargarDatos();

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión del Gimnasio ===");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Ver Clientes");
                Console.WriteLine("3. Editar Cliente");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("5. Reservar Clase");
                Console.WriteLine("6. Ver Reservas de Clientes");
                Console.WriteLine("7. Ver Reservas de Entrenadores");
                Console.WriteLine("8. Registrar Equipo");
                Console.WriteLine("9. Verificar Alertas de Mantenimiento");
                Console.WriteLine("10. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        GymController.RegistrarCliente();
                        break;
                    case "2":
                        GymController.VerClientes();
                        break;
                    case "3":
                        GymController.EditarCliente();
                        break;
                    case "4":
                        GymController.EliminarCliente();
                        break;
                    case "5":
                        GymController.ReservarClase();
                        break;
                    case "6":
                        Console.Write("Ingrese el ID del cliente: ");
                        if (int.TryParse(Console.ReadLine(), out int clienteId))
                        {
                            GymController.VerReservasCliente(clienteId);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;
                    case "7":
                        Console.Write("Ingrese el ID del entrenador: ");
                        if (int.TryParse(Console.ReadLine(), out int entrenadorId))
                        {
                            GymController.VerReservasEntrenador(entrenadorId);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;
                    case "8":
                        GymController.RegistrarEquipo();
                        break;
                    case "9":
                        GymController.VerificarAlertasMantenimiento();
                        break;
                    case "10":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
