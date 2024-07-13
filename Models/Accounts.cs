using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ATM_project.Models; // Customer sınıfının namespace'i

namespace ATMWithdrawalApi.Models
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_Account { get; set; } 

        [Required]
        public int Balance { get; set; }

        [ForeignKey("Customer")]
        public long ID_Customer { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
