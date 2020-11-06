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
    public class AberturasController : Controller
    {
        private readonly TaxiContexto _context;

        public AberturasController(TaxiContexto context)
        {
            _context = context;
        }

        // GET: Aberturas
        public async Task<IActionResult> Index()
        {
            var taxiContexto = _context.Aberturas.Include(a => a.Carro);
            return View(await taxiContexto.ToListAsync());
        }

        // GET: Aberturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abertura = await _context.Aberturas
                .Include(a => a.Carro)
                .FirstOrDefaultAsync(m => m.AberturaID == id);
            if (abertura == null)
            {
                return NotFound();
            }

            return View(abertura);
        }

        // GET: Aberturas/Create
        public IActionResult Create()
        {
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID");
            return View();
        }

        // POST: Aberturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AberturaID,Dia,Hora,CarroID")] Abertura abertura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abertura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID", abertura.CarroID);
            return View(abertura);
        }

        // GET: Aberturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abertura = await _context.Aberturas.FindAsync(id);
            if (abertura == null)
            {
                return NotFound();
            }
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID", abertura.CarroID);
            return View(abertura);
        }

        // POST: Aberturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AberturaID,Dia,Hora,CarroID")] Abertura abertura)
        {
            if (id != abertura.AberturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abertura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AberturaExists(abertura.AberturaID))
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
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "CarroID", abertura.CarroID);
            return View(abertura);
        }

        // GET: Aberturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abertura = await _context.Aberturas
                .Include(a => a.Carro)
                .FirstOrDefaultAsync(m => m.AberturaID == id);
            if (abertura == null)
            {
                return NotFound();
            }

            return View(abertura);
        }

        // POST: Aberturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abertura = await _context.Aberturas.FindAsync(id);
            _context.Aberturas.Remove(abertura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AberturaExists(int id)
        {
            return _context.Aberturas.Any(e => e.AberturaID == id);
        }
    }
}
