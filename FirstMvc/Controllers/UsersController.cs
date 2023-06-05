using FirstMvc.Data.Entities;
using FirstMvc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvc.Controllers;

// Route constraints:
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-7.0#route-constraints

[Route("/users")]
public class UsersController : Controller {
    private readonly IUsersService usersService;

    public UsersController(IUsersService usersServiceFromDI) {
        usersService = usersServiceFromDI;
    }

    // GET /users
    [HttpGet]
    public IActionResult Index()
        => View(usersService.GetAll());

    // GET /users/{id}
    [HttpGet("{id:int:min(1)}")]
    public IActionResult Details(int id) {
        var item = usersService.GetById(id);
        if(item == null)
            return BadRequest($"No user with id = {id}");
        return View(item);
    }

    // GET /users/create
    [HttpGet("create")]
    public IActionResult Create() {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User model) {
        if(!ModelState.IsValid)
            return View(model);

        usersService.Add(model);
        //return View(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public ActionResult Edit(int id) {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection) {
        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }

    [HttpGet("delete/{id}")]
    public IActionResult Delete(int id)  {
        var item = usersService.GetById(id);
        if(item == null)
            return RedirectToAction(nameof(Index));
        return View(item);
    }

    // POST: Users/Delete/5
    [HttpPost("[controller]/Delete/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteAction(int id) {
        try {
            usersService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }
}
