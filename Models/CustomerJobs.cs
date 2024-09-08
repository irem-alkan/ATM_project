using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMWithdrawalApi.Models
{
    public class CustomerJobs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }

        
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }

        public virtual Customer? Customers { get; set; }
    }
}
