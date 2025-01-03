﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunTech.Models;

namespace SunTech.Controllers
{
    public class MonitoramentoController : Controller
    {
        private readonly Contexto _context;

        public MonitoramentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Monitoramento
                public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.Monitoramento != null ?
                          View(await _context.Monitoramento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Monitoramento'  is null.");
            }
            else
            {
                var media =
                    _context.Monitoramento
                    .Where(x => x.Cliente.NomeCliente.Contains( pesquisa ) )
                    .OrderBy(x => x.Cliente);

                return View(media);
            }
        }

        // GET: Monitoramento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Monitoramento == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramento
                .Include(m => m.Cliente)
                .Include(m => m.Placa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramento == null)
            {
                return NotFound();
            }

            return View(monitoramento);
        }

        // GET: Monitoramento/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente");
            ViewData["PlacaId"] = new SelectList(_context.Placa, "Id", "NomePlaca");
            return View();
        }

        // POST: Monitoramento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlacaId,QuantidadePlaca,ClienteId,DataInstalacao,DataUltimaManutencao")] Monitoramento monitoramento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitoramento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", monitoramento.ClienteId);
            ViewData["PlacaId"] = new SelectList(_context.Placa, "Id", "NomePlaca", monitoramento.PlacaId);
            return View(monitoramento);
        }

        // GET: Monitoramento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Monitoramento == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramento.FindAsync(id);
            if (monitoramento == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", monitoramento.ClienteId);
            ViewData["PlacaId"] = new SelectList(_context.Placa, "Id", "NomePlaca", monitoramento.PlacaId);
            return View(monitoramento);
        }

        // POST: Monitoramento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlacaId,QuantidadePlaca,ClienteId,DataInstalacao,DataUltimaManutencao")] Monitoramento monitoramento)
        {
            if (id != monitoramento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monitoramento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonitoramentoExists(monitoramento.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", monitoramento.ClienteId);
            ViewData["PlacaId"] = new SelectList(_context.Placa, "Id", "NomePlaca", monitoramento.PlacaId);
            return View(monitoramento);
        }

        // GET: Monitoramento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Monitoramento == null)
            {
                return NotFound();
            }

            var monitoramento = await _context.Monitoramento
                .Include(m => m.Cliente)
                .Include(m => m.Placa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitoramento == null)
            {
                return NotFound();
            }

            return View(monitoramento);
        }

        // POST: Monitoramento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Monitoramento == null)
            {
                return Problem("Entity set 'Contexto.Monitoramento'  is null.");
            }
            var monitoramento = await _context.Monitoramento.FindAsync(id);
            if (monitoramento != null)
            {
                _context.Monitoramento.Remove(monitoramento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonitoramentoExists(int id)
        {
          return (_context.Monitoramento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
