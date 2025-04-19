using Library_Management_System.Models;
using Library_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorService service;
        public AuthorController(IAuthorService _service)
        {
            service = _service;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await service.GetAllAsync();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Author a)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(a);
                await service.Save();
                return RedirectToAction("Index");
            }
            return View(a);
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await service.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var author = await service.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await service.DeleteAsync(id);
            await service.Save();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await service.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author a)
        {
            if (ModelState.IsValid)
            {
                service.Update(a);
                await service.Save();
                return RedirectToAction("Index");
            }
            return View(a);
        }
    }
}
