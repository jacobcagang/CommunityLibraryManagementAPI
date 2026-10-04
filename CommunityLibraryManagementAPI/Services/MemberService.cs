using CommunityLibraryManagementAPI.Models.Domain;
using CommunityLibraryManagementAPI.Models.Dto;
using CommunityLibraryManagementAPI.Repositories;


namespace CommunityLibraryManagementAPI.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MemberDto>> GetAllAsync()
        {
            var members = await _repository.GetAllAsync();

            return members.Select(member => new MemberDto
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                MembershipDate = member.MembershipDate
            }).ToList();
        }

        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var member = await _repository.GetByIdAsync(id);

            if (member == null)
            {
                return null;
            }

            return new MemberDto
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                MembershipDate = member.MembershipDate
            };
        }

        public async Task<MemberDto> CreateAsync(MemberDto dto)
        {
            var member = new Member
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                MembershipDate = dto.MembershipDate == default
                    ? DateTime.UtcNow
                    : dto.MembershipDate
            };

            var createdMember = await _repository.AddAsync(member);

            return new MemberDto
            {
                Id = createdMember.Id,
                Name = createdMember.Name,
                Email = createdMember.Email,
                Phone = createdMember.Phone,
                MembershipDate = createdMember.MembershipDate
            };
        }

        public async Task<bool> UpdateAsync(int id, MemberDto dto)
        {
            var member = await _repository.GetByIdAsync(id);

            if (member == null)
            {
                return false;
            }

            member.Name = dto.Name;
            member.Email = dto.Email;
            member.Phone = dto.Phone;

            return await _repository.UpdateAsync(member);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}