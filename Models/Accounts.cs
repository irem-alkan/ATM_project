using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMWithdrawalApi.Models
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        public int Balance { get; set; }

        [ForeignKey("Customer")]
        public long CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
