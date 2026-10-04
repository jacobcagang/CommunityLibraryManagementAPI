using CommunityLibraryManagementAPI.Models.Dto;

namespace CommunityLibraryManagementAPI.Services
{
    public interface IMemberService
    {
        Task<List<MemberDto>> GetAllAsync();
        Task<MemberDto?> GetByIdAsync(int id);
        Task<MemberDto> CreateAsync(MemberDto dto);
        Task<bool> UpdateAsync(int id, MemberDto dto);
        Task<bool> DeleteAsync(int id);
    }
}