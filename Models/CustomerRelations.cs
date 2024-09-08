using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMWithdrawalApi.Models
{
    public class CustomerRelations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? RelationType { get; set; } 
        
        public string? RelatedPersonFullName { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }

        public virtual Customer? Customers { get; set; }
    }
}
