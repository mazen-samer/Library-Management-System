using Library_Management_System.Models;
using Library_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService service;
        public CategoryController(ICategoryService _service)
        {
            service = _service;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await service.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post: category/create
        [HttpPost]
        public async Task<IActionResult> Create(Category c)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(c);
                await service.Save();
                return Content("Saved Nigga: " + c.Name);
            }
            return View(c);
        }

        //Get: category/delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await service.DeleteAsync(id);
            await service.Save();
            return RedirectToAction("Index");
        }

    }
}
