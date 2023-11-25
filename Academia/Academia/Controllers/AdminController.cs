using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Controllers;

[Authorize(Roles = "Administrador")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
