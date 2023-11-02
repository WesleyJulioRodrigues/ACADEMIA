using Microsoft.AspNetCore.Mvc;
using Professor.Models;
using Academia.Data;
using Microsoft.EntityFrameworkCore;

namespace Academia.Controllers
{
    public class ComidaRecomendadasController : Controller
    {
        private readonly Contexto _context;

        public ComidaRecomendadasController(Contexto context)
        {
            _context = context;
        }

        // Ação para adicionar uma ComidaRecomendada
        public IActionResult AdicionarComidaRecomendada(ComidaRecomendada comida)
        {
            _context.ComidasRecomendadas.Add(comida);
            _context.SaveChanges();
            return RedirectToAction("Index"); // Redirecionar para a página inicial ou outra página apropriada
        }

        // Ação para remover uma ComidaRecomendada por ID
        public IActionResult RemoverComidaRecomendada(int id)
        {
            var comida = _context.ComidasRecomendadas.Find(id);
            if (comida != null)
            {
                _context.ComidasRecomendadas.Remove(comida);
                _context.SaveChanges();
            }
            return RedirectToAction("Index"); // Redirecionar para a página inicial ou outra página apropriada
        }

        // Ação para adicionar um Professor
        public IActionResult AdicionarProfessor(professor , Professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return RedirectToAction("Index"); // Redirecionar para a página inicial ou outra página apropriada
        }

        // Ação para remover um Professor por ID
        public IActionResult RemoverProfessor(int id)
        {
            var professor = _context.Professores.Find(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                _context.SaveChanges();
            }
            return RedirectToAction("Index"); // Redirecionar para a página inicial ou outra página apropriada
        }

        // Outras ações e métodos

        public IActionResult Index()
        {
            // Lógica para exibir informações na página inicial
            return View();
        }
    }
}