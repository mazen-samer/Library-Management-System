using Library_Management_System.Models;
using Library_Management_System.Repositories.Interfaces;
using Library_Management_System.Services.Interfaces;

namespace Library_Management_System.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository repo;
        private readonly IWebHostEnvironment _env;

        public BookService(IBookRepository _repo, IWebHostEnvironment env)
        {
            repo = _repo;
            _env = env;
        }

        public async Task CreateAsync(Book book, IFormFile coverImageFile)
        {
            // Set AvailableCopies = Capacity
            book.AvailableCopies = book.TotalCopies;

            // Handle Image
            if (coverImageFile != null && coverImageFile.Length > 0)
            {
                var folderPath = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(folderPath); // Ensure it exists

                var fileExtension = Path.GetExtension(coverImageFile.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await coverImageFile.CopyToAsync(stream);
                }

                book.CoverImagePath = "/images/" + fileName;
            }

            await repo.AddAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var existingBook = await repo.GetByIdAsync(id);
            if (existingBook == null)
                return;

            if (!string.IsNullOrEmpty(existingBook.CoverImagePath))
            {
                var relativePath = existingBook.CoverImagePath.TrimStart('/'); // e.g., "images/xyz.png"
                var oldPath = Path.Combine(_env.WebRootPath, relativePath);

                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                    Console.WriteLine("##################DELETED############");
                }
            }

            await repo.DeleteAsync(id);
        }


        public async Task<IEnumerable<Book>> GetAllAsync(string? authorName, string? categoryName)
        {
            var books = await repo.GetAllAsync();

            if (!string.IsNullOrEmpty(authorName))
                books = books.Where(b => b.Author.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(categoryName))
                books = books.Where(b => b.Category.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            return books;
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            return repo.GetByIdAsync(id);
        }

        public Task Save()
        {
            return repo.Save();
        }

        public async Task Update(Book updatedBook, IFormFile? newImage)
        {
            var existingBook = await repo.GetByIdAsync(updatedBook.Id);
            if (existingBook == null) return;

            // Update fields
            existingBook.Title = updatedBook.Title;
            existingBook.Description = updatedBook.Description;
            existingBook.AuthorId = updatedBook.AuthorId;
            existingBook.CategoryId = updatedBook.CategoryId;
            existingBook.TotalCopies = updatedBook.TotalCopies;
            existingBook.AvailableCopies = updatedBook.TotalCopies; // Optional

            if (newImage != null && newImage.Length > 0)
            {
                // Delete old image if exists
                if (!string.IsNullOrEmpty(existingBook.CoverImagePath))
                {
                    var relativePath = existingBook.CoverImagePath?.TrimStart('/');

                    var oldPath = Path.Combine(_env.WebRootPath, relativePath);

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                        Console.WriteLine("##################DELETED############");
                    }
                }

                // Save new image
                var extension = Path.GetExtension(newImage.FileName);
                var fileName = Guid.NewGuid().ToString() + extension;
                var path = Path.Combine(_env.WebRootPath, "images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await newImage.CopyToAsync(stream);
                }

                existingBook.CoverImagePath = "/images/" + fileName;
            }

            repo.Update(existingBook);
            await repo.Save();
        }
    }
}
