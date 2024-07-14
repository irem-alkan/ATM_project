using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMWithdrawalApi.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Type is required")]
        public string CustomerType { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = string.Empty;

        public decimal? NetIncomeAmount { get; set; }

        //public ICollection<Accounts>? Accounts { get; set; }
       //public ICollection<DebtPayments>? DebtPayments { get; set; }
       // public ICollection<CustomerJob> CustomerJobs { get; set; }
        //public ICollection<CustomerRelation>? CustomerRelations { get; set; }
    }
}
