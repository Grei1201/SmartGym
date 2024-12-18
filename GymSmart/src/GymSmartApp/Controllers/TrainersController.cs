using Microsoft.AspNetCore.Mvc;
using GymSmartApp.Data;
using GymSmartApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TrainnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var trainners = await _context.Trainners.ToListAsync();
            return View(trainners);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainner = await _context.Trainners
                .FirstOrDefaultAsync(m => m.IdTrainner == id);
            if (trainner == null)
            {
                return NotFound();
            }

            return View(trainner);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdTrainner,Name,LastName1,LastName2,Password,Phone,City,Direcition,IdLocal")] Trainner trainner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainner);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainner = await _context.Trainners.FindAsync(id);
            if (trainner == null)
            {
                return NotFound();
            }
            return View(trainner);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdTrainner,Name,LastName1,LastName2,Password,Phone,City,Direcition,IdLocal")] Trainner trainner)
        {
            if (id != trainner.IdTrainner)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainnerExists(trainner.IdTrainner))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trainner);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainner = await _context.Trainners
                .FirstOrDefaultAsync(m => m.IdTrainner == id);
            if (trainner == null)
            {
                return NotFound();
            }

            return View(trainner);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainner = await _context.Trainners.FindAsync(id);
            _context.Trainners.Remove(trainner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainnerExists(int id)
        {
            return _context.Trainners.Any(e => e.IdTrainner == id);
        }
    }
