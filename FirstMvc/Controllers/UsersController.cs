using FirstMvc.Models;
using FirstMvc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvc.Controllers;

public class UsersController : Controller {
    private readonly IUsersService usersService;

    public UsersController(IUsersService usersServiceFromDI) {
        usersService = usersServiceFromDI;
    }

    // GET: Users
    public IActionResult Index()
        => View(usersService.GetAll());

    // GET: Users/Details/5
    public IActionResult Details(int id) {
        var item = usersService.GetById(id);
        if(item == null)
            return NotFound();
        return View(item);
    }

    // GET: Users/Create
    public IActionResult Create() {
        return View();
    }

    // POST: Users/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User model) {
        if(!ModelState.IsValid)
            return View(model);

        usersService.Add(model);
        //return View(model);
        return RedirectToAction(nameof(Index));
    }

    // GET: Users/Edit/5
    public ActionResult Edit(int id) {
        return View();
    }

    // POST: Users/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection) {
        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }

    // GET: Users/Delete/5
    [HttpGet]
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
