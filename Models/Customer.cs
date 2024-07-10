using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATMWithdrawalApi.Models
{
    public class Customer
    {
        
        [Required]
        public string? CustomerType { get; set; }

        [Required]
        [Key]
        public int ID_Customer { get; set; } = 0; 

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;
    }
}
