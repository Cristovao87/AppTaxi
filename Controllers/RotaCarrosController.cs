using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTaxi.Dados;
using AppTaxi.Models;

namespace AppTaxi.Controllers
{
    public class RotaCarrosController : Controller
    {
        private readonly TaxiContexto _context;

        public RotaCarrosController(TaxiContexto context)
        {
            _context = context;
        }

        // GET: RotaCarros
        public async Task<IActionResult> Index()
        {
            var taxiContexto = _context.RotaCarro.Include(r => r.Carro).Include(r => r.Rota);
            return View(await taxiContexto.ToListAsync());
        }

        // GET: RotaCarros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotaCarro = await _context.RotaCarro
                .Include(r => r.Carro)
                .Include(r => r.Rota)
                .FirstOrDefaultAsync(m => m.RotaID == id);
            if (rotaCarro == null)
            {
                return NotFound();
            }

            return View(rotaCarro);
        }

        // GET: RotaCarros/Create
        public IActionResult Create()
        {
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID");
            ViewData["RotaID"] = new SelectList(_context.Rotas, "RotaID", "RotaID");
            return View();
        }

        // POST: RotaCarros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RotaID,CarroID")] RotaCarro rotaCarro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rotaCarro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID", rotaCarro.CarroID);
            ViewData["RotaID"] = new SelectList(_context.Rotas, "RotaID", "RotaID", rotaCarro.RotaID);
            return View(rotaCarro);
        }

        // GET: RotaCarros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotaCarro = await _context.RotaCarro.FindAsync(id);
            if (rotaCarro == null)
            {
                return NotFound();
            }
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID", rotaCarro.CarroID);
            ViewData["RotaID"] = new SelectList(_context.Rotas, "RotaID", "RotaID", rotaCarro.RotaID);
            return View(rotaCarro);
        }

        // POST: RotaCarros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RotaID,CarroID")] RotaCarro rotaCarro)
        {
            if (id != rotaCarro.RotaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rotaCarro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotaCarroExists(rotaCarro.RotaID))
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
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID", rotaCarro.CarroID);
            ViewData["RotaID"] = new SelectList(_context.Rotas, "RotaID", "RotaID", rotaCarro.RotaID);
            return View(rotaCarro);
        }

        // GET: RotaCarros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotaCarro = await _context.RotaCarro
                .Include(r => r.Carro)
                .Include(r => r.Rota)
                .FirstOrDefaultAsync(m => m.RotaID == id);
            if (rotaCarro == null)
            {
                return NotFound();
            }

            return View(rotaCarro);
        }

        // POST: RotaCarros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rotaCarro = await _context.RotaCarro.FindAsync(id);
            _context.RotaCarro.Remove(rotaCarro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RotaCarroExists(int id)
        {
            return _context.RotaCarro.Any(e => e.RotaID == id);
        }
    }
}
