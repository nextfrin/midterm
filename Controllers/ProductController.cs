using Microsoft.AspNetCore.Mvc;
using midterm.Data;
using midterm.Models;

namespace midterm.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext_db;
        public ProductsController(ApplicationDbContext db){_db = db; }

        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _db.Product.Find(id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _db.Products.Remove(product);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}