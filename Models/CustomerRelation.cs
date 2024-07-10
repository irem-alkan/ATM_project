using System.ComponentModel.DataAnnotations;

namespace ATMWithdrawalApi.Models
{
    public class CustomerRelation
    {
        [Key]
        public int ID_Customer { get; set; } = 0;
        public string RelationName { get; set; } = string.Empty;
        public int Relatienid { get; set; }
        public string? RelatedPersonFullName { get; set; }
    }
}
