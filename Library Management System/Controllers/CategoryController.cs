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
        public IActionResult Create()
        {
            return View();
        }

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
    }
}
