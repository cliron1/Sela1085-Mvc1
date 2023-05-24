using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMvc.Controllers;

public class HomeController : Controller {
    // localhost:7777/
    public IActionResult Index() => View();

    // localhost:7777/Home/Privacy
    public IActionResult Privacy() => View();

    // localhost:7777/Home/Nir
    public IActionResult Nir() {
        var nir = new Person {
            Id = 1,
            Name = "Nir",
            Age = 24,
            Skills = new List<string> {
                "Html", "Css", "js", "Asp.Net Core MVC"
            }
        };

        ViewData["other"] = 77;
        ViewBag.minAge = 18;

        return View(nir);
    }

    // localhost:7777/Home/Oriel
    public IActionResult Oriel() => View();





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
