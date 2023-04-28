using System.Diagnostics;
using EmployeeConsultApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeConsultApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation($"{nameof(HomeController)}:{nameof(Index)}");
        return RedirectToAction("GetAll", "Employee");
    }

    public IActionResult Privacy()
    {
        _logger.LogInformation($"{nameof(HomeController)}:{nameof(Privacy)}");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogWarning($"{nameof(EmployeeController)}:{nameof(Error)}");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}