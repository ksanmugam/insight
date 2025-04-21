namespace BigPurpleBank.Models.v2.Banking
{
    public class ResponseBankingAccountListV2
    {
        public ICollection<BankingAccountV2> Data { get; set; }
        public LinksPaginated Links { get; set; }
        public MetaPaginated Meta { get; set; }
    }
}
