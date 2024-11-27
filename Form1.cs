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

        // Evento que se ejecutar� cuando el usuario haga clic en el bot�n
        private void btnEjecutarL�gica_Click(object sender, EventArgs e)
        {
            var clienteController = new ClienteController();
            var membresiaController = new MembresiaController();

            // Mostrar todos los clientes
            Console.WriteLine("Clientes actuales:");
            var clientes = clienteController.ObtenerClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.Id}, Nombre: {cliente.Nombre}, Membres�a Activa: {cliente.MembresiaActiva}");
            }

            // Asignar una membres�a a un cliente
            Console.WriteLine("\nAsignando membres�a...");
            int clienteId = 1; // Cambia seg�n un ID v�lido en tu JSON
            string tipoMembresia = "Mensual"; // Cambia seg�n las opciones en membresias.json
            clienteController.AsignarMembresia(clienteId, tipoMembresia);

            // Verificar los datos del cliente despu�s de asignar la membres�a
            Console.WriteLine("\nClientes despu�s de asignar membres�a:");
            clientes = clienteController.ObtenerClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.Id}, Nombre: {cliente.Nombre}, Membres�a Activa: {cliente.MembresiaActiva}, Fecha Inicio: {cliente.FechaInicioMembresia}");
            }
        }
    }
}
