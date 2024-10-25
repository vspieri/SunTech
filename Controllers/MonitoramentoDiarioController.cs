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
    public class MonitoramentoDiarioController : Controller
    {
        private readonly Contexto _context;

        public MonitoramentoDiarioController(Contexto context)
        {
            _context = context;
        }

        // GET: MonitoramentoDiario

        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.MonitoramentoDiario != null ?
                          View(await _context.MonitoramentoDiario.ToListAsync()) :
                          Problem("Entity set 'Contexto.MonitoramentoDiario' is null.");
            }
            else
            {
                var mediadiaria =
                    _context.MonitoramentoDiario
                    .Where(x => x.Monitoramento.Placa.NomePlaca.Contains(pesquisa))
                    .OrderBy(x => x.Monitoramento.PlacaId);

                return View(mediadiaria);
            }
        }


        // GET: MonitoramentoDiario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonitoramentoDiario == null)
            {
                return NotFound();
            }

            var monitoramentoDiario = await _context.MonitoramentoDiario
                .Include(m => m.Monitoramento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramentoDiario == null)
            {
                return NotFound();
            }

            return View(monitoramentoDiario);
        }

        // GET: MonitoramentoDiario/Create
        public IActionResult Create()
        {
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id");
            return View();
        }

        // POST: MonitoramentoDiario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDia,MediaDia,MonitoramentoId")] MonitoramentoDiario monitoramentoDiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitoramentoDiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id", monitoramentoDiario.MonitoramentoId);
            return View(monitoramentoDiario);
        }

        // GET: MonitoramentoDiario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonitoramentoDiario == null)
            {
                return NotFound();
            }

            var monitoramentoDiario = await _context.MonitoramentoDiario.FindAsync(id);
            if (monitoramentoDiario == null)
            {
                return NotFound();
            }
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id", monitoramentoDiario.MonitoramentoId);
            return View(monitoramentoDiario);
        }

        // POST: MonitoramentoDiario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataDia,MediaDia,MonitoramentoId")] MonitoramentoDiario monitoramentoDiario)
        {
            if (id != monitoramentoDiario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monitoramentoDiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonitoramentoDiarioExists(monitoramentoDiario.Id))
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
            ViewData["MonitoramentoId"] = new SelectList(_context.Monitoramento, "Id", "Id", monitoramentoDiario.MonitoramentoId);
            return View(monitoramentoDiario);
        }

        // GET: MonitoramentoDiario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonitoramentoDiario == null)
            {
                return NotFound();
            }

            var monitoramentoDiario = await _context.MonitoramentoDiario
                .Include(m => m.Monitoramento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramentoDiario == null)
            {
                return NotFound();
            }

            return View(monitoramentoDiario);
        }

        // POST: MonitoramentoDiario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonitoramentoDiario == null)
            {
                return Problem("Entity set 'Contexto.MonitoramentoDiario'  is null.");
            }
            var monitoramentoDiario = await _context.MonitoramentoDiario.FindAsync(id);
            if (monitoramentoDiario != null)
            {
                _context.MonitoramentoDiario.Remove(monitoramentoDiario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonitoramentoDiarioExists(int id)
        {
          return (_context.MonitoramentoDiario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
