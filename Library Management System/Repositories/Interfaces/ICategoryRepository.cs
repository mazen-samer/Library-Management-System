using Library_Management_System.Models;

namespace Library_Management_System.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task CreateAsync(Category category);
        void Update(Category category);
        Task DeleteAsync(int id);
        Task Save();
    }

}
