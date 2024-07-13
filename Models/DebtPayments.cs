using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMWithdrawalApi.Models
{
    public class DebtPayments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public string? Description { get; set; }

       
        [ForeignKey("Customer")]
        public long ID_Customer { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
