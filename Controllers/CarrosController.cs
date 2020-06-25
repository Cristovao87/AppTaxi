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
    public class CarrosController : Controller
    {
        private readonly TaxiContexto _context;

        public CarrosController(TaxiContexto context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var taxiContexto = _context.Carros.Include(c => c.Cobrador).Include(c => c.Motorista);
            return View(await taxiContexto.ToListAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Cobrador)
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.CarroID == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            ViewData["CobradorID"] = new SelectList(_context.Cobradores, "CobradorID", "CobradorID");
            ViewData["MotoristaID"] = new SelectList(_context.Motoristas, "MotoristaID", "MotoristaID");
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarroID,Matricula,MotoristaID,CobradorID")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CobradorID"] = new SelectList(_context.Cobradores, "CobradorID", "CobradorID", carro.CobradorID);
            ViewData["MotoristaID"] = new SelectList(_context.Motoristas, "MotoristaID", "MotoristaID", carro.MotoristaID);
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            ViewData["CobradorID"] = new SelectList(_context.Cobradores, "CobradorID", "CobradorID", carro.CobradorID);
            ViewData["MotoristaID"] = new SelectList(_context.Motoristas, "MotoristaID", "MotoristaID", carro.MotoristaID);
            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarroID,Matricula,MotoristaID,CobradorID")] Carro carro)
        {
            if (id != carro.CarroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.CarroID))
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
            ViewData["CobradorID"] = new SelectList(_context.Cobradores, "CobradorID", "CobradorID", carro.CobradorID);
            ViewData["MotoristaID"] = new SelectList(_context.Motoristas, "MotoristaID", "MotoristaID", carro.MotoristaID);
            return View(carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Cobrador)
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.CarroID == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.CarroID == id);
        }
    }
}
