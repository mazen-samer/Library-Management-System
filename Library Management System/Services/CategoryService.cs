using Library_Management_System.Models;
using Library_Management_System.Repositories.Interfaces;
using Library_Management_System.Services.Interfaces;

namespace Library_Management_System.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository repo;
        public CategoryService(ICategoryRepository _repo)
        {
            repo = _repo;
        }

        public Task CreateAsync(Category category)
        {
            return repo.AddAsync(category);
        }

        public Task DeleteAsync(int id)
        {
            return repo.DeleteAsync(id);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            return repo.GetByIdAsync(id);
        }

        public void Update(Category category)
        {
            repo.Update(category);
        }

        public Task Save()
        {
            return repo.Save();
        }
    }
}
