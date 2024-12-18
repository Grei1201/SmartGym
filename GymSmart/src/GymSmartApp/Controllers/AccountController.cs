using Microsoft.AspNetCore.Mvc;
using GymSmartApp.Data;
using GymSmartApp.Models;
using System.Linq;
using System.Threading.Tasks;

 public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para mostrar el formulario de registro
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Método para procesar el registro de usuario
        [HttpPost]
        public async Task<IActionResult> Register(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(client);
        }

        // Método para mostrar el formulario de inicio de sesión
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Método para procesar el inicio de sesión
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var user = _context.Clients.SingleOrDefault(u => u.Name == Username && u.Password == Password);

            if (user != null)
            {
                // Lógica para inicio de sesión exitoso
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Lógica para credenciales inválidas
                ViewBag.ErrorMessage = "Credenciales inválidas. Por favor, inténtalo de nuevo.";
                return View();
            }
        }
    }
