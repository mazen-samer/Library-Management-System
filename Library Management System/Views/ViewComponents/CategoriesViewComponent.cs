using Library_Management_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class CategoriesViewComponent : ViewComponent
{
    ApplicationDbContext context;
    public CategoriesViewComponent(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await context.Categories.ToListAsync();
        return View(categories);
    }
}

