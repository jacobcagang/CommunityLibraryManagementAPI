using CommunityLibraryManagementAPI.Models.Dto;

namespace CommunityLibraryManagementAPI.Services
{
    public interface ILoanService
    {
        Task<List<LoanDto>> GetAllAsync();

        Task<LoanDto?> GetByIdAsync(int id);

        Task<LoanDto?> CreateAsync(LoanDto dto);

        Task<bool> ReturnBookAsync(int id);

        Task<bool> DeleteAsync(int id);
    }
}