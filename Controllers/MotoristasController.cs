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
    public class MotoristasController : Controller
    {
        private readonly TaxiContexto _context;

        public MotoristasController(TaxiContexto context)
        {
            _context = context;
        }

        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motoristas.ToListAsync());
        }

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                .FirstOrDefaultAsync(m => m.MotoristaID == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotoristaID,Nome,BI")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotoristaID,Nome,BI")] Motorista motorista)
        {
            if (id != motorista.MotoristaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaExists(motorista.MotoristaID))
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
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                .FirstOrDefaultAsync(m => m.MotoristaID == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);
            _context.Motoristas.Remove(motorista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaExists(int id)
        {
            return _context.Motoristas.Any(e => e.MotoristaID == id);
        }
    }
}
