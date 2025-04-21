namespace BigPurpleBank.Models.v2.Banking
{
    public class ResponseBankingAccountListV2
    {
        public required ICollection<BankingAccountV2> Data { get; set; } = new List<BankingAccountV2>();
        public required LinksPaginated Links { get; set; } = new LinksPaginated { Self = String.Empty };
        public required MetaPaginated Meta { get; set; } = new MetaPaginated();
    }
}
