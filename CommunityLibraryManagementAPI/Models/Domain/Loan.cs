using System.ComponentModel.DataAnnotations;

namespace CommunityLibraryManagementAPI.Models.Domain
{
    public class Loan
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int MemberId { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.UtcNow;

        public DateTime? ReturnDate { get; set; }

        public Book? Book { get; set; }

        public Member? Member { get; set; }
    }
}