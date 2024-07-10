using System.ComponentModel.DataAnnotations;

namespace ATMWithdrawalApi.Models
{
    public class Account
    {
        [Key]
        public int ID_Customer { get; set; }
        public string ID_Account { get; set; } = string.Empty;
        public int Balance { get; set; }
        public string CardNumber { get; set; }
        public string PIN { get; set; }
    }
}
