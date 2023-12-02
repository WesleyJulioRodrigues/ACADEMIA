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
        
        private readonly IWebHostEnvironment _hostEnvironment;
  
    
        public ComidasController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao, Foto")] Comida comida, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comida);
                await _context.SaveChangesAsync();

                if (formFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = comida.Id.ToString() + Path.GetExtension(formFile.FileName);
                    string uploads = Path.Combine(wwwRootPath, @"imgs\comidas");
                    string newFile = Path.Combine(uploads, fileName);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    comida.Foto = "/imgs/comidas/" + fileName;
                    await _context.SaveChangesAsync();
                }

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Foto")] Comida comida, IFormFile formFile)
        {
            if (id != comida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               try
                {

                    // Se tiver arquivo de imagem, salva a imagem no servidor com o ID do filme e adiciona o nome e caminho da imagem no banco
                    if (formFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        if (comida.Foto != null)
                        {
                            string oldFile = Path.Combine(wwwRootPath, comida.Foto.TrimStart('\\'));
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }

                        string fileName = comida.Id.ToString() + Path.GetExtension(formFile.FileName);
                        string uploads = Path.Combine(wwwRootPath, @"imgs\comidas");
                        string newFile = Path.Combine(uploads, fileName);
                        using (var stream = new FileStream(newFile, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        comida.Foto = "/imgs/comidas/" + fileName;
                        await _context.SaveChangesAsync();
                    }

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

        // GET: Professores/Delete/5
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

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comidas == null)
            {
                return Problem("Entity set 'AppDbContext.Comidas'  is null.");
            }
            var comida = await _context.Professores.FindAsync(id);
            if (comida != null)
            {
                _context.Professores.Remove(comida);
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
