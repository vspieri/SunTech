using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunTech.Models;

namespace SunTech.Controllers
{
    public class PlacaController : Controller
    {
        private readonly Contexto _context;

        public PlacaController(Contexto context)
        {
            _context = context;
        }

        // GET: Placa
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Placa.Include(p => p.TipoPlaca);
            return View(await contexto.ToListAsync());
        }

        // GET: Placa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Placa == null)
            {
                return NotFound();
            }

            var placa = await _context.Placa
                .Include(p => p.TipoPlaca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placa == null)
            {
                return NotFound();
            }

            return View(placa);
        }

        // GET: Placa/Create
        public IActionResult Create()
        {
            ViewData["TipoPlacaId"] = new SelectList(_context.TipoPlaca, "Id", "NomeTipoPlaca");
            return View();
        }

        // POST: Placa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomePlaca,TipoPlacaId,TamanhoPlaca")] Placa placa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPlacaId"] = new SelectList(_context.TipoPlaca, "Id", "NomeTipoPlaca", placa.TipoPlacaId);
            return View(placa);
        }

        // GET: Placa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Placa == null)
            {
                return NotFound();
            }

            var placa = await _context.Placa.FindAsync(id);
            if (placa == null)
            {
                return NotFound();
            }
            ViewData["TipoPlacaId"] = new SelectList(_context.TipoPlaca, "Id", "NomeTipoPlaca", placa.TipoPlacaId);
            return View(placa);
        }

        // POST: Placa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomePlaca,TipoPlacaId,TamanhoPlaca")] Placa placa)
        {
            if (id != placa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacaExists(placa.Id))
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
            ViewData["TipoPlacaId"] = new SelectList(_context.TipoPlaca, "Id", "NomeTipoPlaca", placa.TipoPlacaId);
            return View(placa);
        }

        // GET: Placa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Placa == null)
            {
                return NotFound();
            }

            var placa = await _context.Placa
                .Include(p => p.TipoPlaca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placa == null)
            {
                return NotFound();
            }

            return View(placa);
        }

        // POST: Placa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Placa == null)
            {
                return Problem("Entity set 'Contexto.Placa'  is null.");
            }
            var placa = await _context.Placa.FindAsync(id);
            if (placa != null)
            {
                _context.Placa.Remove(placa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacaExists(int id)
        {
          return (_context.Placa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
