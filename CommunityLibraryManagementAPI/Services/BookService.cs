using CommunityLibraryManagementAPI.Models.Domain;
using CommunityLibraryManagementAPI.Models.Dto;
using CommunityLibraryManagementAPI.Repositories;

namespace CommunityLibraryManagementAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();

            return books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Category = book.Category,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies,
                PublishedYear = book.PublishedYear,
                IsAvailable = book.IsAvailable
            }).ToList();
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Category = book.Category,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies,
                PublishedYear = book.PublishedYear,
                IsAvailable = book.IsAvailable
            };
        }

        public async Task<BookDto> CreateAsync(BookDto dto)
        {
            var existingBook = await _repository.GetByISBNAsync(dto.ISBN);

            if (existingBook != null)
            {
                throw new InvalidOperationException("A book with this ISBN already exists.");
            }

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                Category = dto.Category,
                TotalCopies = dto.TotalCopies,
                AvailableCopies = dto.AvailableCopies,
                PublishedYear = dto.PublishedYear,
                IsAvailable = dto.AvailableCopies > 0
            };

            var createdBook = await _repository.AddAsync(book);

            return new BookDto
            {
                Id = createdBook.Id,
                Title = createdBook.Title,
                Author = createdBook.Author,
                ISBN = createdBook.ISBN,
                Category = createdBook.Category,
                TotalCopies = createdBook.TotalCopies,
                AvailableCopies = createdBook.AvailableCopies,
                PublishedYear = createdBook.PublishedYear,
                IsAvailable = createdBook.IsAvailable
            };
        }

        public async Task<bool> UpdateAsync(int id, BookDto dto)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
            {
                return false;
            }

            var existingBook = await _repository.GetByISBNAsync(dto.ISBN);

            if (existingBook != null && existingBook.Id != id)
            {
                throw new InvalidOperationException("A book with this ISBN already exists.");
            }

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.Category = dto.Category;
            book.TotalCopies = dto.TotalCopies;
            book.AvailableCopies = dto.AvailableCopies;
            book.PublishedYear = dto.PublishedYear;
            book.IsAvailable = dto.AvailableCopies > 0;

            return await _repository.UpdateAsync(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}