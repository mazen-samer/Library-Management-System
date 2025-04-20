using Library_Management_System.Models;

namespace Library_Management_System.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task CreateAsync(Book book, IFormFile coverImageFile);
        Task Update(Book book, IFormFile newImage);
        Task DeleteAsync(int id);
        Task Save();
    }
}
