using big_purple_bank.Server.Database;
using BigPurpleBank.Enum;
using BigPurpleBank.Filter;
using BigPurpleBank.Interfaces;
using BigPurpleBank.Models;
using BigPurpleBank.Models.v2.Banking;

namespace BigPurpleBank.Services
{
    public class BankingService : IBankingService
    {
        private readonly DatabaseContext _context;
        public BankingService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResponseBankingAccountListV2> GetAccountsAsync()
        {
            // TODO: Link db context to query

            // Simulate an asynchronous operation
            await Task.Delay(1000);
            // Return a dummy response for demonstration purposes
            return new ResponseBankingAccountListV2
            {
                Data = new List<BankingAccountV2>
                {
                    new BankingAccountV2
                    {
                        AccountId = "123456789",
                        DisplayName = "John Doe",
                        CreationDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                        ProductCategory = Enum.BankingProductCategory.BUSINESS_LOANS,
                        OpenStatus = OpenStatus.CLOSED,
                        AccountOwnership = AccountOwnership.UNKNOWN,
                        ProductName = "Business Loan",
                        MaskedNumber = "****1234",
                    }
                },
                Links = new LinksPaginated { Self = String.Empty },
                Meta = new MetaPaginated
                {
                    TotalPages = 1,
                    TotalRecords = 1
                }
            };
        }
    }
}
