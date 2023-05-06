using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.ViewModels;
using System.Numerics;

namespace Shop.Controllers
{
    public class BooksController : Controller
    {
        private LibraryContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        public BooksController(LibraryContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index(int page = 1)
        {
            var books = _db.Products.ToList();
            int pageSize = 8;
            var count = books.Count;
            var items = books.Skip((page - 1) * pageSize).Take(pageSize);
            PageViewModel pvm = new PageViewModel(count, page, pageSize);
            BookPagingViewModel bookPagging = new BookPagingViewModel
            {
                PageViewModel = pvm,
                Books = items
            };
            return View(bookPagging);
        }
        public IActionResult Add()
        {
            var categories = _db.Categories.ToList();

            ViewData["Categories"] = categories;

            return View();
        }
        [HttpPost]

        public IActionResult Add(Book book)
        {
            book.DateAdd = DateTime.UtcNow;

            if (book.CategoryId == null)
            {
                ViewBag.Message = $"Необходимо добавить категорию";
                return View();
            }
            else if (book != null)
            {
                _db.Products.Add(book);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int bookId)
        {
            var book = _db.Products.FirstOrDefault(p => p.Id == bookId);
            if (book != null)
            {
                return View(book);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Update(int bookId)
        {
            var book = _db.Products.FirstOrDefault(a => a.Id == bookId);
            var categories = _db.Categories.ToList();

            ViewData["Categories"] = categories;
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
           
            if (book != null)
            {
                _db.Products.Update(book);
                _db.SaveChanges();
                return Redirect("Index");

            }
            else
                return NotFound();
        }
    }
}
