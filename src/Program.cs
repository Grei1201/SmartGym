using System;

namespace GymManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;  // Variable para controlar el bucle del menú.

            while (running)
            {
                Console.Clear();  // Limpia la consola.
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
                        GymController.RegistrarCliente();  // Llama al método para registrar un nuevo cliente.
                        break;
                    case "2":
                        GymController.VerClientes();  // Llama al método para ver la lista de clientes.
                        break;
                    case "3":
                        GymController.EditarCliente();  // Llama al método para editar un cliente.
                        break;
                    case "4":
                        GymController.EliminarCliente();  // Llama al método para eliminar un cliente.
                        break;
                    case "5":
                        running = false;  // Cambia la variable 'running' a false para salir del bucle.
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Inténtelo nuevamente.");  // Mensaje para opciones inválidas.
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();  // Espera a que el usuario presione una tecla para continuar.
                }
            }
        }
    }
}
