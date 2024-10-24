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
    public class TipoPlacaController : Controller
    {
        private readonly Contexto _context;

        public TipoPlacaController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoPlaca
        public async Task<IActionResult> Index()
        {
              return _context.TipoPlaca != null ? 
                          View(await _context.TipoPlaca.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoPlaca'  is null.");
        }

        // GET: TipoPlaca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoPlaca == null)
            {
                return NotFound();
            }

            var tipoPlaca = await _context.TipoPlaca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPlaca == null)
            {
                return NotFound();
            }

            return View(tipoPlaca);
        }

        // GET: TipoPlaca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPlaca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTipoPlaca")] TipoPlaca tipoPlaca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPlaca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPlaca);
        }

        // GET: TipoPlaca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoPlaca == null)
            {
                return NotFound();
            }

            var tipoPlaca = await _context.TipoPlaca.FindAsync(id);
            if (tipoPlaca == null)
            {
                return NotFound();
            }
            return View(tipoPlaca);
        }

        // POST: TipoPlaca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTipoPlaca")] TipoPlaca tipoPlaca)
        {
            if (id != tipoPlaca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPlaca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPlacaExists(tipoPlaca.Id))
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
            return View(tipoPlaca);
        }

        // GET: TipoPlaca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoPlaca == null)
            {
                return NotFound();
            }

            var tipoPlaca = await _context.TipoPlaca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPlaca == null)
            {
                return NotFound();
            }

            return View(tipoPlaca);
        }

        // POST: TipoPlaca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoPlaca == null)
            {
                return Problem("Entity set 'Contexto.TipoPlaca'  is null.");
            }
            var tipoPlaca = await _context.TipoPlaca.FindAsync(id);
            if (tipoPlaca != null)
            {
                _context.TipoPlaca.Remove(tipoPlaca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPlacaExists(int id)
        {
          return (_context.TipoPlaca?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
