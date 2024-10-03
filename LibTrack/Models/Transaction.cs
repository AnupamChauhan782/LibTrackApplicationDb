using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibTrack.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? TotalRent { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
    }
}
