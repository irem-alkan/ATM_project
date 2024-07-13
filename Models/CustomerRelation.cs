using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMWithdrawalApi.Models
{
    public class CustomerRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Relatienid { get; set; }

        [Required]
        public string? RelationName { get; set; } 
        
        public string? RelatedPersonFullName { get; set; }

        [ForeignKey("Customer")]
        public long ID_Customer { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
