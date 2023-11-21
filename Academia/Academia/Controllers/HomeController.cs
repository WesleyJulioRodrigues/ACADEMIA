using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Academia.Models;
using Academia.Data;
using Academia.ViewModels;

namespace Academia.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _contexto;

    public HomeController(ILogger<HomeController> logger, AppDbContext contexto)
    {
        _logger = logger;
        _contexto = contexto;
    }

    public IActionResult Index()
    {
        HomeVM home = new() {
            Comidas  = _contexto.Comidas.ToList(),
            Professores = _contexto.Professores.ToList(),
            Exercicios = _contexto.Exercicios.ToList()
        };
        return View(home);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
