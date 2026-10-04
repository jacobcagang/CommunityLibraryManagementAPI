using CommunityLibraryManagementAPI.Models.Domain;

namespace CommunityLibraryManagementAPI.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();

        Task<Loan?> GetByIdAsync(int id);

        Task<Loan> AddAsync(Loan loan);

        Task<bool> UpdateAsync(Loan loan);

        Task<bool> DeleteAsync(int id);

    }
}