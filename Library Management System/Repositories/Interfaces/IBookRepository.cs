using Library_Management_System.Models;

namespace Library_Management_System.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task DeleteAsync(int id);
        void Update(Book book);
        Task Save();
    }
}
