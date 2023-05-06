using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using Library.ViewModels;
using System.Numerics;

namespace Library.Controllers
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

        public IActionResult Index(BooksSortState sortOrder = BooksSortState.NameAsc, int page = 1)
        {
            List<Book> book = _db.Books.ToList();
            ViewBag.TitleSort = sortOrder == BooksSortState.NameAsc ? BooksSortState.NameDesc : BooksSortState.NameAsc;
            ViewBag.AuthorSort = sortOrder == BooksSortState.AuthorAsc ? BooksSortState.AuthorDesc : BooksSortState.AuthorAsc;
            ViewBag.DateAddedSort = sortOrder == BooksSortState.DateAddDesc ? BooksSortState.DateAddDesc : BooksSortState.DateAddAsc;
            switch (sortOrder)
            {
                case BooksSortState.NameAsc:
                    book = book.OrderBy(x => x.Name).ToList();
                    break;
                case BooksSortState.NameDesc:
                    book = book.OrderByDescending(x => x.Name).ToList();
                    break;
                case BooksSortState.AuthorAsc:
                    book = book.OrderBy(x => x.Author).ToList();
                    break;
                case BooksSortState.AuthorDesc:
                    book = book.OrderByDescending(x => x.Author).ToList();
                    break;
                case BooksSortState.DateAddAsc:
                    book = book.OrderBy(x => x.DateAdd).ToList();
                    break;
                case BooksSortState.DateAddDesc:
                    book = book.OrderByDescending(x => x.DateAdd).ToList();
                    break;
            }
            return View(book.ToList());

            var books = _db.Books.ToList();
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
                _db.Books.Add(book);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int bookId)
        {
            var book = _db.Books.FirstOrDefault(p => p.Id == bookId);
            if (book != null)
            {
                return View(book);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Update(int bookId)
        {
            var book = _db.Books.FirstOrDefault(a => a.Id == bookId);
            var categories = _db.Categories.ToList();

            ViewData["Categories"] = categories;
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
           
            if (book != null)
            {
                _db.Books.Update(book);
                _db.SaveChanges();
                return Redirect("Index");

            }
            else
                return NotFound();
        }
    }
}
