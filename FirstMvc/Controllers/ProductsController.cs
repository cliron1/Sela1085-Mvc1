using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvc.Controllers;

public class ProductsController : Controller {
    private readonly List<Product> data;

    public ProductsController() {
        data = new List<Product> {
            new Product { Id = 77, Name = "Keyboard", Price = 50},
            new Product { Id = 78, Name = "Mouse", Price = 35},
        };
    }

    // /Products
    [HttpGet]
    public IActionResult Index() =>
        // Todo: Get the list from the database
        View(data);

    // /Products/View/7
    [HttpGet]
    public IActionResult Details(int id) {
        var item = data.FirstOrDefault(x => x.Id == id);
        if(item == null)
            return NotFound();
        return View(item);
    }

    // /Products/Edit/7
    [HttpGet]
    public IActionResult Edit(int id) {
        var item = data.FirstOrDefault(x => x.Id == id);
        if(item == null)
            return NotFound();
        return View(item);
    }

    // /Products/Edit
    [HttpPost]
    public IActionResult Edit(Product item) {
        //ModelState.AddModelError("", "Stam error");

        if(!item.Price.HasValue) {
            item.Price = 10;
            ModelState.Clear();
            TryValidateModel(item);
        }

        if(!ModelState.IsValid) {
            return View(item);
        }

        // Todo: Save to DB

        //return View();
        return RedirectToAction(nameof(Index));
    }


    // /Products/Delete/7
    public IActionResult Delete(int id) => View();

    // Method || VERB

    // READ:   GET      <URL>
    // CREATE: POST     <URL> + Data
    // UPDATE: PUT      <URL> + Data
    // DELETEL DELETE   <URL>

}
