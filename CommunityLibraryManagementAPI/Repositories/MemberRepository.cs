using CommunityLibraryManagementAPI.Models.DATA;
using CommunityLibraryManagementAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommunityLibraryManagementAPI.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAllAsync()
        {
            return await _context.Members
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Member> AddAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public async Task<bool> UpdateAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return false;
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}