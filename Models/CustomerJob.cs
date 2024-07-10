using System.ComponentModel.DataAnnotations;

namespace ATMWithdrawalApi.Models
{
    public class CustomerJob
    {
        [Key]
        public int JObId { get; set; }
        public string?  CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Position { get; set; } = string.Empty;
        public int ID_Customer { get; set; }
        public string Salary { get; set; } = string.Empty;
    }
}
