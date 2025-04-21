using BigPurpleBank.Enum;

namespace BigPurpleBank.Entities
{
    public class Account
    {
        public required string AccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public required string DisplayName { get; set; }
        public string? Nickname { get; set; }
        public OpenStatus OpenStatus { get; set; } = OpenStatus.CLOSED;
        public bool IsOwned { get; set; }
        public AccountOwnership AccountOwnership { get; set; } = AccountOwnership.UNKNOWN;
        public required string MaskedNumber { get; set; }
        public BankingProductCategory ProductCategory { get; set; }
        public required string ProductName { get; set; }
    }
}
