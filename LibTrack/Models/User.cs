using System.ComponentModel.DataAnnotations;

namespace LibTrack.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User_Name is required!")]
        [MaxLength(50, ErrorMessage = "Character max length 50")]
        public string User_Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Navigation property to Transactions
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
