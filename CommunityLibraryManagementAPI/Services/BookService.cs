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
                PublishedYear = book.PublishedYear,
                IsAvailable = book.IsAvailable
            };
        }

        public async Task<BookDto> CreateAsync(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublishedYear = dto.PublishedYear,
                IsAvailable = true
            };

            var createdBook = await _repository.AddAsync(book);

            return new BookDto
            {
                Id = createdBook.Id,
                Title = createdBook.Title,
                Author = createdBook.Author,
                ISBN = createdBook.ISBN,
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

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.PublishedYear = dto.PublishedYear;

            return await _repository.UpdateAsync(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}