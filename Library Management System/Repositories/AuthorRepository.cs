using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        ApplicationDbContext context;
        public AuthorRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task CreateAsync(Author author)
        {
            await context.Authors.AddAsync(author);
        }

        public async Task DeleteAsync(int id)
        {
            var author = await context.Authors.FindAsync(id);
            if (author != null)
            {
                context.Authors.Remove(author);
            }
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await context.Authors.FindAsync(id);
        }

        public void Update(Author author)
        {
            context.Authors.Update(author);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
