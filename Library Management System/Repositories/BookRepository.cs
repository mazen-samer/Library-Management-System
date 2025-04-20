using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories
{
    public class BookRepository : IBookRepository
    {
        ApplicationDbContext context;
        public BookRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                context.Books.Remove(book);
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Book book)
        {
            context.Books.Update(book);
        }
    }
}
