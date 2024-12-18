using Microsoft.AspNetCore.Mvc;
using GymSmartApp.Data;
using GymSmartApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _context.Classes.ToListAsync();
            return View(classes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymClass = await _context.Classes
                .FirstOrDefaultAsync(m => m.IdClass == id);
            if (gymClass == null)
            {
                return NotFound();
            }

            return View(gymClass);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdClass,NameClass,Day,Hour,IdTrainner,Space")] Class gymClass)
        {
            if (ModelState.IsValid)
            {
[_{{{CITATION{{{_1{](https://github.com/NikolIT/WebApplicationTireFitting/tree/b018032cfe470b7d4d1b576d974b2f1a353ca1d1/WebApplicationTireFitting%2FControllers%2FClientsController.cs)[_{{{CITATION{{{_2{](https://github.com/Igorseven/Store/tree/0f1a415d7adc1595450a6660b9aa49f5d06fb819/CarStore.Store.MVC%2FControllers%2FClientsController.cs)[_{{{CITATION{{{_3{](https://github.com/sandiks/ClientsOrdersManager/tree/86d4d8dae3397a57058fd920c4ad37fb43507b1e/Controllers%2FClientsController.cs)[_{{{CITATION{{{_4{](https://github.com/rosenpapazov/CourseWorkApp/tree/7a8f1a3c6718010bb7d8426076f45b74f4370ab3/CourseWorkApp%2FControllers%2FClientsController.cs)[_{{{CITATION{{{_5{](https://github.com/Lluminatarion-8431/CoreHealthAndFitness/tree/63010134da04b62cca6c3d59d30792f2c8e70b9b/Controllers%2FClientsController.cs)[_{{{CITATION{{{_6{](https://github.com/thduc2806/CMSApplication/tree/dabb74eab11490a5c872247f0631e95957a307c3/Controllers%2FTrainnersController.cs)