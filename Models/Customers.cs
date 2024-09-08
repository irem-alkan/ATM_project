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

        [Required(ErrorMessage = "TC is required")]
        public string TC { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        // Navigation properties
        public ICollection<CustomerJobs> CustomerJobs { get; set; } = new List<CustomerJobs>();
        public ICollection<CustomerRelations> CustomerRelations { get; set; } = new List<CustomerRelations>();
    }
}
