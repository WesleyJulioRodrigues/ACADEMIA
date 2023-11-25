using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academia.Data;
using Academia.Models;

namespace Academia.Controllers
{
    public class ComidasController : Controller
    {
        private readonly AppDbContext _context;

        public ComidasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Comidas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Comidas.ToListAsync());
        }

        // GET: Comidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comidas == null)
            {
                return NotFound();
            }

            var comida = await _context.Comidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comida == null)
            {
                return NotFound();
            }

            return View(comida);
        }

        // GET: Comidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Tipo,Calorias,Foto")] Comida comida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comida);
        }

        // GET: Comidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comidas == null)
            {
                return NotFound();
            }

            var comida = await _context.Comidas.FindAsync(id);
            if (comida == null)
            {
                return NotFound();
            }
            return View(comida);
        }

        // POST: Comidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Tipo,Calorias,Foto")] Comida comida)
        {
            if (id != comida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComidaExists(comida.Id))
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
            return View(comida);
        }

        // GET: Comidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comidas == null)
            {
                return NotFound();
            }

            var comida = await _context.Comidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comida == null)
            {
                return NotFound();
            }

            return View(comida);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comidas == null)
            {
                return Problem("Entity set 'AppDbContext.Comidas'  is null.");
            }
            var comida = await _context.Comidas.FindAsync(id);
            if (comida != null)
            {
                _context.Comidas.Remove(comida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComidaExists(int id)
        {
          return _context.Comidas.Any(e => e.Id == id);
        }
    }
}
