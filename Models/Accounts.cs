using System.ComponentModel.DataAnnotations;

namespace ATMWithdrawalApi.Models
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }
        public int ID_Customer { get; set; }
        public string ID_Account { get; set; } = string.Empty;
        public int Balance { get; set; }
        public Customer Customer { get; set; }

    }
}
