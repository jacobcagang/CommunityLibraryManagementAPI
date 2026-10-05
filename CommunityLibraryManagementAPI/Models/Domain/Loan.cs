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

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Borrowed";

        public Book? Book { get; set; }

        public Member? Member { get; set; }
    }
}