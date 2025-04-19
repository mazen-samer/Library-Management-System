using Library_Management_System.Models;

namespace Library_Management_System.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task CreateAsync(Category category);
        void Update(Category category);
        Task DeleteAsync(int id);
        Task Save();
    }
}
