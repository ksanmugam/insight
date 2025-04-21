using BigPurpleBank.Enum;
using BigPurpleBank.Filter;
using BigPurpleBank.Interfaces;
using BigPurpleBank.Models.v2;
using BigPurpleBank.Models.v2.Banking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;
using static BigPurpleBank.Helpers.Contants;

namespace BigPurpleBank.Controllers.v2
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : Controller
    {
        private readonly ILogger<BankingController> _logger;
        private readonly IBankingService _bankingService;

        public BankingController(IBankingService bankingService, ILogger<BankingController> logger)
        {
            _bankingService = bankingService;
            _logger = logger;
        }

        /// <summary>
        /// Get Accounts
        /// </summary>
        /// <remarks>Obtain a list of accounts.</remarks>
        /// <param name="productCategory">Used to filter results on the productCategory field applicable to accounts. Any one of the valid values for this field can be supplied. If absent then all accounts returned.</param>
        /// <param name="openStatus">Used to filter results according to open/closed status. Values can be OPEN, CLOSED or ALL. If absent then ALL is assumed.</param>
        /// <param name="isOwned">	Filters accounts based on whether they are owned by the authorised customer. true for owned accounts, false for unowned accounts and absent for all accounts.</param>
        /// <param name="page">Page of results to request (standard pagination).</param>
        /// <param name="pageSize">Page size to request. Default is 25 (standard pagination).</param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="406">NotAcceptable</response>
        /// <response code="422">UnprocessableEntity</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("Accounts")]
        [ProducesResponseType(typeof(ResponseBankingAccountListV2), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorListV2), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorListV2), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(ResponseErrorListV2), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ResponseErrorListV2), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccounts(
            [FromQuery(Name = "product-category")] BankingProductCategory? productCategory,
            [FromQuery(Name = "open-status")] OpenStatus openStatus = OpenStatus.ALL,
            [FromQuery(Name = "is-owned")] bool? isOwned = null,
            [FromQuery(Name = "page")] int page = 1,
            [FromQuery(Name = "page-size")] int pageSize = 25)
        {
            try
            {
                var errors = new ResponseErrorListV2() { Errors = new List<ErrorV2>() };

                // product category validation
                if (productCategory.HasValue &&
                   (!System.Enum.IsDefined(typeof(BankingProductCategory), productCategory.Value)))
                {
                    errors.Errors.Add(new ErrorV2
                    {
                        Code = ErrorCodes.InvalidField,
                        Title = "Invalid Field",
                        Detail = "product-category"
                    });
                }

                if (!System.Enum.IsDefined(typeof(OpenStatus), openStatus))
                {
                    errors.Errors.Add(new ErrorV2
                    {
                        Code = ErrorCodes.InvalidField,
                        Title = "Invalid Field",
                        Detail = "open-status"
                    });
                }

                if (errors.Errors.Count > 0)
                {
                    return StatusCode(400, errors);
                }

                // max page size for demo error validation
                if (pageSize > MaxPageSize)
                {
                    errors.Errors.Add(new ErrorV2
                    {
                        Code = ErrorCodes.InvalidPage,
                        Title = "Invalid Page",
                        Detail = $"{pageSize}"
                    });
                    return StatusCode(422, errors);
                }

                var accounts = await _bankingService.GetAccountsAsync();

                return Ok(accounts);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing the request.");
                return StatusCode(500, new ResponseErrorListV2
                {
                    Errors = new List<ErrorV2>
                    {
                        new ErrorV2
                        {
                            Code = ErrorCodes.InternalServerError,
                            Title = "Internal Server Error",
                            Detail = "An unexpected error occurred."
                        }
                    }
                });
            }
        }
    }
}
