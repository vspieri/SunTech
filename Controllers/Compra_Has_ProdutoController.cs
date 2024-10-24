using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunTech.Models;

namespace SunTech.Controllers
{
    public class Compra_Has_ProdutoController : Controller
    {
        private readonly Contexto _context;

        public Compra_Has_ProdutoController(Contexto context)
        {
            _context = context;
        }

        // GET: Compra_Has_Produto
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Compra_Has_Produto.Include(c => c.Compra).Include(c => c.Produto);
            return View(await contexto.ToListAsync());
        }

        // GET: Compra_Has_Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compra_Has_Produto == null)
            {
                return NotFound();
            }

            var compra_Has_Produto = await _context.Compra_Has_Produto
                .Include(c => c.Compra)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra_Has_Produto == null)
            {
                return NotFound();
            }

            return View(compra_Has_Produto);
        }

        // GET: Compra_Has_Produto/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compra, "Id", "Id");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "NomeProduto", "NomeProduto");
            return View();
        }

        // POST: Compra_Has_Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompraId,ProdutoId,QuantidadeProduto,ValorUnitario,ValorTotalProduto")] Compra_Has_Produto compra_Has_Produto)
        {
            if (ModelState.IsValid)
            {
                var produto = _context.Produto.FirstOrDefault(x => x.Id == compra_Has_Produto.ProdutoId);
                compra_Has_Produto.ValorUnitario = produto.PrecoProduto;
                compra_Has_Produto.ValorTotalProduto = compra_Has_Produto.QuantidadeProduto * produto.PrecoProduto;

                /* TODO - MELHORAR UM DIA, BOA SORTE NOVO PROFESSOR !*/
                var compra = _context.Compra.FirstOrDefault(x => x.Id == compra_Has_Produto.CompraId);
                var listaProdutos = _context.Compra_Has_Produto
                    .Where(x => x.CompraId == compra_Has_Produto.CompraId)
                    .GroupBy(x => x.CompraId)
                    .Select(group => group.Sum(item => item.ValorTotalProduto));
                if (listaProdutos.Count() != 0)
                    foreach (var item in listaProdutos)
                        compra.ValorTotal = item + compra_Has_Produto.ValorTotalProduto;
                else
                    compra.ValorTotal = compra_Has_Produto.ValorTotalProduto;
                /* FIM MELHORAR UM DIA*/

                _context.Update(compra);
                _context.Add(compra_Has_Produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compra, "Id", "Id", compra_Has_Produto.CompraId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", compra_Has_Produto.ProdutoId);
            return View(compra_Has_Produto);
        }

        // GET: Compra_Has_Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Compra_Has_Produto == null)
            {
                return NotFound();
            }

            var compra_Has_Produto = await _context.Compra_Has_Produto.FindAsync(id);
            if (compra_Has_Produto == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compra, "Id", "Id", compra_Has_Produto.CompraId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", compra_Has_Produto.ProdutoId);
            return View(compra_Has_Produto);
        }

        // POST: Compra_Has_Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompraId,ProdutoId,QuantidadeProduto,ValorUnitario,ValorTotalProduto")] Compra_Has_Produto compra_Has_Produto)
        {
            if (id != compra_Has_Produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra_Has_Produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Compra_Has_ProdutoExists(compra_Has_Produto.Id))
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
            ViewData["CompraId"] = new SelectList(_context.Compra, "Id", "Id", compra_Has_Produto.CompraId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", compra_Has_Produto.ProdutoId);
            return View(compra_Has_Produto);
        }

        // GET: Compra_Has_Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compra_Has_Produto == null)
            {
                return NotFound();
            }

            var compra_Has_Produto = await _context.Compra_Has_Produto
                .Include(c => c.Compra)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra_Has_Produto == null)
            {
                return NotFound();
            }

            return View(compra_Has_Produto);
        }

        // POST: Compra_Has_Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compra_Has_Produto == null)
            {
                return Problem("Entity set 'Contexto.Compra_Has_Produto'  is null.");
            }
            var compra_Has_Produto = await _context.Compra_Has_Produto.FindAsync(id);
            if (compra_Has_Produto != null)
            {
                /* TODO - MELHORAR UM DIA, BOA SORTE NOVO PROFESSOR !*/
                var compra = _context.Compra.FirstOrDefault(x => x.Id == compra_Has_Produto.CompraId);
                var listaProdutos = _context.Compra_Has_Produto
                    .Where(x => x.CompraId == compra_Has_Produto.CompraId)
                    .GroupBy(x => x.CompraId)
                    .Select(group => group.Sum(item => item.ValorTotalProduto));
                if (listaProdutos.Count() != 0)
                    foreach (var item in listaProdutos)
                        compra.ValorTotal = item - compra_Has_Produto.ValorTotalProduto;
                else
                    compra.ValorTotal = compra_Has_Produto.ValorTotalProduto;
                /* FIM MELHORAR UM DIA*/
                _context.Update(compra);
                _context.Compra_Has_Produto.Remove(compra_Has_Produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Compra_Has_ProdutoExists(int id)
        {
            return (_context.Compra_Has_Produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
