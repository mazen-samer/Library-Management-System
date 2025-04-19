using Library_Management_System.Models;

namespace Library_Management_System.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task CreateAsync(Author author);
        void Update(Author author);
        Task DeleteAsync(int id);
        Task Save();
    }
}
