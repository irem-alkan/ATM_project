using System.ComponentModel.DataAnnotations;

namespace ATMWithdrawalApi.Models
{
    public class DebtPayments
    {
        [Key]
        public int ID_Customer { get; set; } = 0;
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
