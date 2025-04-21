namespace BigPurpleBank.Models.v2.Banking
{
    public class ResponseBankingAccountListV2
    {
        public required ICollection<BankingAccountV2> Data { get; set; }
        public required LinksPaginated Links { get; set; }
        public required MetaPaginated Meta { get; set; }
    }
}
