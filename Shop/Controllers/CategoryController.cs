using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Models;
using System.Numerics;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private LibraryContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        public CategoryController(LibraryContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(Category category)
        {
            if (!_db.Categories.Any(p => p.Name == category.Name))
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            else
            {
                ViewBag.Message = $"{category.Name} уже существует";
                return View();
            }
            return RedirectToAction("Index");
        }
        

        [HttpGet]
        public IActionResult Update(int categoryId)
        {
            var category = _db.Categories.FirstOrDefault(a => a.Id == categoryId);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (category != null)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return Redirect("Index");

            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Details(int categoryId)
        {
            var category = _db.Categories.FirstOrDefault(p => p.Id == categoryId);
            if (category != null)
            {
                return View(category);
            }
            return NotFound();
        }

        public IActionResult Delete(int categoryId)
        {
            var category = _db.Categories.FirstOrDefault(p => p.Id == categoryId);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return Redirect("Index");
            }else
                return NotFound();
            
        }
    }
}
