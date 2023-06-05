using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMvc.Controllers;

[Route("/")]
public class HomeController : Controller {

    [HttpGet]
    public IActionResult Index() => View();

    [HttpGet("/privacy")]
    public IActionResult Privacy() => View();


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
