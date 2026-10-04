using CommunityLibraryManagementAPI.Models.DATA;
using CommunityLibraryManagementAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommunityLibraryManagementAPI.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Loan> AddAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return loan;
        }

        public async Task<bool> UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);

            if (loan == null)
            {
                return false;
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}