using CommunityLibraryManagementAPI.Models.Domain;

namespace CommunityLibraryManagementAPI.Repositories
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task<Member> AddAsync(Member member);
        Task<bool> UpdateAsync(Member member);
        Task<bool> DeleteAsync(int id);
    }
}