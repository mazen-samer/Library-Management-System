using Library_Management_System.Models;
using Library_Management_System.Repositories.Interfaces;
using Library_Management_System.Services.Interfaces;

namespace Library_Management_System.Services
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository repo;
        public AuthorService(IAuthorRepository _repo)
        {
            repo = _repo;
        }
        public Task CreateAsync(Author author)
        {
            return repo.CreateAsync(author);
        }

        public Task DeleteAsync(int id)
        {
            return repo.DeleteAsync(id);
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public Task<Author?> GetByIdAsync(int id)
        {
            return repo.GetByIdAsync(id);
        }

        public void Update(Author author)
        {
            repo.Update(author);
        }
        public async Task Save()
        {
            await repo.Save();
        }
    }
}
