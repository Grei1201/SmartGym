using System;
using System.Windows.Forms;

namespace SmartGym2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Evento que se ejecutará cuando el usuario haga clic en el botón
        private void btnEjecutarLógica_Click(object sender, EventArgs e)
        {
            var clienteController = new ClienteController();
            var membresiaController = new MembresiaController();

            // Mostrar todos los clientes
            Console.WriteLine("Clientes actuales:");
            var clientes = clienteController.ObtenerClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.Id}, Nombre: {cliente.Nombre}, Membresía Activa: {cliente.MembresiaActiva}");
            }

            // Asignar una membresía a un cliente
            Console.WriteLine("\nAsignando membresía...");
            int clienteId = 1; // Cambia según un ID válido en tu JSON
            string tipoMembresia = "Mensual"; // Cambia según las opciones en membresias.json
            clienteController.AsignarMembresia(clienteId, tipoMembresia);

            // Verificar los datos del cliente después de asignar la membresía
            Console.WriteLine("\nClientes después de asignar membresía:");
            clientes = clienteController.ObtenerClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.Id}, Nombre: {cliente.Nombre}, Membresía Activa: {cliente.MembresiaActiva}, Fecha Inicio: {cliente.FechaInicioMembresia}");
            }
        }
    }
}
