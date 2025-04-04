using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PC1_GABRIEL.Models;

namespace PC1_GABRIEL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

    public IActionResult Cambio(decimal cantidadEnvias)
{
    decimal tipoCambio = 0.75M; // Tasa de cambio de BRL a PEN
    decimal cantidadRecibe = cantidadEnvias * tipoCambio;
    ViewBag.CantidadRecibe = cantidadRecibe;
    return View("FormularioBoleta");
}

public IActionResult GenerarBoleta(string nombre, string dni, decimal monto)
{
    ViewBag.Nombre = nombre;
    ViewBag.DNI = dni;
    ViewBag.Monto = monto;
    return View("BoletaGenerada");
}


}
