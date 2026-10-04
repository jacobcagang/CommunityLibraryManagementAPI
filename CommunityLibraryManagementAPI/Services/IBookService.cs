using CommunityLibraryManagementAPI.Models.Dto;

namespace CommunityLibraryManagementAPI.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();

        Task<BookDto?> GetByIdAsync(int id);

        Task<BookDto> CreateAsync(BookDto dto);

        Task<bool> UpdateAsync(int id, BookDto dto);

        Task<bool> DeleteAsync(int id);
    }
}