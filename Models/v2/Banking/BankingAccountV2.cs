using BigPurpleBank.Enum;
using BigPurpleBank.Helpers;
using System.ComponentModel;

namespace BigPurpleBank.Models.v2.Banking
{
    public class BankingAccountV2
    {
        public string AccountId { get; set; }
        public string CreationDate { get; set; }
        public string DisplayName { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public OpenStatus OpenStatus { get; set; } = OpenStatus.OPEN;
        public bool IsOwned { get; set; } = true;
        public AccountOwnership AccountOwnership { get; set; }
        public string MaskedNumber { get; set; }
        public BankingProductCategory ProductCategory { get; set; }
        public string ProductName { get; set; }
    }
}
