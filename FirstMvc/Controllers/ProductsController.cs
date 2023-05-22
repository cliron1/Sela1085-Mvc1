using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvc.Controllers;

public class ProductsController : Controller {
    private List<Product> data;

    public ProductsController() {
        data = new List<Product> {
            new Product { Id = 77, Name = "Keyboard", Price = 50},
            new Product { Id = 78, Name = "Mouse", Price = 35},
        };
    }


    // /Products
    [HttpGet]
    public IActionResult Index() {
        // Todo: Get the list from the database
        return View(data);
    }

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
        // Todo: Save to DB
        return View();
    }


    // /Products/Delete/7
    public IActionResult Delete(int id) {
        return View();
    }

    // Method || VERB

    // READ:   GET      <URL>
    // CREATE: POST     <URL> + Data
    // UPDATE: PUT      <URL> + Data
    // DELETEL DELETE   <URL>

}
