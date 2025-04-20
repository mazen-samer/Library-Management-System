using Library_Management_System.Models;
using Library_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Management_System.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly ICategoryService categoryService;

        public BookController(IBookService _bookService, IAuthorService _authorService, ICategoryService _categoryService)
        {
            bookService = _bookService;
            authorService = _authorService;
            categoryService = _categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = new SelectList(await authorService.GetAllAsync(), "Id", "Name");
            ViewBag.Categories = new SelectList(await categoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book, IFormFile? CoverImage)
        {
            if (ModelState.IsValid)
            {
                await bookService.CreateAsync(book, CoverImage);
                await bookService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Authors = new SelectList(await authorService.GetAllAsync(), "Id", "Name", book.AuthorId);
            ViewBag.Categories = new SelectList(await categoryService.GetAllAsync(), "Id", "Name", book.CategoryId);

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Authors = new SelectList(await authorService.GetAllAsync(), "Id", "Name", book.AuthorId);
            ViewBag.Categories = new SelectList(await categoryService.GetAllAsync(), "Id", "Name", book.CategoryId);

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] Book b, IFormFile newImage)
        {
            if (b.Id != id)
            {
                return BadRequest();
            }
            Console.WriteLine("I came here");
            await bookService.Update(b, newImage);
            await bookService.Save();
            return RedirectToAction("Index");
        }
    }
}
