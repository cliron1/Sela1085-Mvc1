using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvc.Controllers {
    public class BooksController : Controller {
        // GET: BooksController
        public ActionResult Index() => View(new List<Book>());

        // GET: BooksController/Details/5
        public ActionResult Details(int id) => View();

        // GET: BooksController/Create
        public ActionResult Create() => View(new Book());

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id) => View();

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book model) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id) => View();

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book model) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}
