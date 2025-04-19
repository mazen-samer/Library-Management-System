using Library_Management_System.Models;

namespace Library_Management_System.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task CreateAsync(Author author);
        void Update(Author author);
        Task DeleteAsync(int id);
        Task Save();
    }
}
