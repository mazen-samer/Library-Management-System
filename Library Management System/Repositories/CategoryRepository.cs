using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task AddAsync(Category category)
        {
            await context.Categories.AddAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
        }
    }
}
