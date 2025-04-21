using BigPurpleBank.Enum;

namespace BigPurpleBank.Entities
{
    public class Account
    {
        public string AccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public string DisplayName { get; set; }
        public string Nickname { get; set; }
        public OpenStatus OpenStatus { get; set; } = OpenStatus.CLOSED;
        public bool IsOwned { get; set; }
        public AccountOwnership AccountOwnership { get; set; } = AccountOwnership.UNKNOWN;
        public string MaskedNumber { get; set; }
        public BankingProductCategory ProductCategory { get; set; }
        public string ProductName { get; set; }
    }
}
