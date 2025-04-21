using BigPurpleBank.Filter;
using BigPurpleBank.Models.v2.Banking;

namespace BigPurpleBank.Interfaces
{
    public interface IBankingService
    {
        Task<ResponseBankingAccountListV2> GetAccountsAsync();
    }
}
