using Library_Management_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class AuthorsViewComponent : ViewComponent
{
    ApplicationDbContext context;
    public AuthorsViewComponent(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var authors = await context.Authors.ToListAsync();
        return View(authors);
    }
}

