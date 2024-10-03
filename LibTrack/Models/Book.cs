using System.ComponentModel.DataAnnotations;

namespace LibTrack.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
      
        public decimal RentPerDay { get; set; }

        // Navigation property to Transactions
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
