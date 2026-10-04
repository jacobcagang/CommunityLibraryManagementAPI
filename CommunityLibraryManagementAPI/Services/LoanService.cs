using CommunityLibraryManagementAPI.Models.Domain;
using CommunityLibraryManagementAPI.Models.Dto;
using CommunityLibraryManagementAPI.Repositories;

namespace CommunityLibraryManagementAPI.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public LoanService(
            ILoanRepository loanRepository,
            IBookRepository bookRepository,
            IMemberRepository memberRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }

        public async Task<List<LoanDto>> GetAllAsync()
        {
            var loans = await _loanRepository.GetAllAsync();

            return loans.Select(loan => new LoanDto
            {
                Id = loan.Id,
                BookId = loan.BookId,
                MemberId = loan.MemberId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate
            }).ToList();
        }

        public async Task<LoanDto?> GetByIdAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);

            if (loan == null)
            {
                return null;
            }

            return new LoanDto
            {
                Id = loan.Id,
                BookId = loan.BookId,
                MemberId = loan.MemberId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate
            };
        }

        public async Task<LoanDto?> CreateAsync(LoanDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(dto.BookId);

            if (book == null)
            {
                return null;
            }

            var member = await _memberRepository.GetByIdAsync(dto.MemberId);

            if (member == null)
            {
                return null;
            }

            if (!book.IsAvailable)
            {
                return null;
            }

            var loan = new Loan
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                LoanDate = DateTime.UtcNow,
                ReturnDate = null
            };

            var createdLoan = await _loanRepository.AddAsync(loan);

            book.IsAvailable = false;
            await _bookRepository.UpdateAsync(book);

            return new LoanDto
            {
                Id = createdLoan.Id,
                BookId = createdLoan.BookId,
                MemberId = createdLoan.MemberId,
                LoanDate = createdLoan.LoanDate,
                ReturnDate = createdLoan.ReturnDate
            };
        }

        public async Task<bool> ReturnBookAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);

            if (loan == null)
            {
                return false;
            }

            if (loan.ReturnDate != null)
            {
                return false;
            }

            var book = await _bookRepository.GetByIdAsync(loan.BookId);

            if (book == null)
            {
                return false;
            }

            loan.ReturnDate = DateTime.UtcNow;

            book.IsAvailable = true;

            await _loanRepository.UpdateAsync(loan);
            await _bookRepository.UpdateAsync(book);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _loanRepository.DeleteAsync(id);
        }
    }
}