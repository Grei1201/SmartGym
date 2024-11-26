using System;

namespace GymManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Gestión del Gym ");
                Console.WriteLine("1. Registrar nuevo cliente");
                Console.WriteLine("2. Ver lista de clientes");
                Console.WriteLine("3. Editar cliente");
                Console.WriteLine("4. Eliminar cliente");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
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
                        running = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
