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
    public class MonitoramentoMensalController : Controller
    {
        private readonly Contexto _context;

        public MonitoramentoMensalController(Contexto context)
        {
            _context = context;
        }

        // GET: MonitoramentoMensal
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.MonitoramentoMensal != null ?
                          View(await _context.MonitoramentoMensal.ToListAsync()) :
                          Problem("Entity set 'Contexto.MonitoramentoMensal'  is null.");
            }
            else
            {
                var mediamensal =
                    _context.MonitoramentoMensal
                    .Where(x => x.Monitoramento.Placa.NomePlaca.Contains(pesquisa))
                    .OrderBy(x => x.Monitoramento.PlacaId);

                return View(mediamensal);
            }
        }

        // GET: MonitoramentoMensal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonitoramentoMensal == null)
            {
                return NotFound();
            }

            var monitoramentoMensal = await _context.MonitoramentoMensal
                .Include(m => m.Monitoramento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramentoMensal == null)
            {
                return NotFound();
            }

            return View(monitoramentoMensal);
        }

        // GET: MonitoramentoMensal/Create
        public IActionResult Create()
        {
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id");
            return View();
        }

        // POST: MonitoramentoMensal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mes,MediaMensal,MonitoramentoId")] MonitoramentoMensal monitoramentoMensal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitoramentoMensal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id", monitoramentoMensal.MonitoramentoId);
            return View(monitoramentoMensal);
        }

        // GET: MonitoramentoMensal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonitoramentoMensal == null)
            {
                return NotFound();
            }

            var monitoramentoMensal = await _context.MonitoramentoMensal.FindAsync(id);
            if (monitoramentoMensal == null)
            {
                return NotFound();
            }
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id", monitoramentoMensal.MonitoramentoId);
            return View(monitoramentoMensal);
        }

        // POST: MonitoramentoMensal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mes,MediaMensal,MonitoramentoId")] MonitoramentoMensal monitoramentoMensal)
        {
            if (id != monitoramentoMensal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monitoramentoMensal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonitoramentoMensalExists(monitoramentoMensal.Id))
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
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id", monitoramentoMensal.MonitoramentoId);
            return View(monitoramentoMensal);
        }

        // GET: MonitoramentoMensal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonitoramentoMensal == null)
            {
                return NotFound();
            }

            var monitoramentoMensal = await _context.MonitoramentoMensal
                .Include(m => m.Monitoramento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramentoMensal == null)
            {
                return NotFound();
            }

            return View(monitoramentoMensal);
        }

        // POST: MonitoramentoMensal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonitoramentoMensal == null)
            {
                return Problem("Entity set 'Contexto.MonitoramentoMensal'  is null.");
            }
            var monitoramentoMensal = await _context.MonitoramentoMensal.FindAsync(id);
            if (monitoramentoMensal != null)
            {
                _context.MonitoramentoMensal.Remove(monitoramentoMensal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonitoramentoMensalExists(int id)
        {
          return (_context.MonitoramentoMensal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
