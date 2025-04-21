using BigPurpleBank.Controllers.v2;
using BigPurpleBank.Enum;
using BigPurpleBank.Interfaces;
using BigPurpleBank.Models.v2;
using BigPurpleBank.Models.v2.Banking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using static BigPurpleBank.Helpers.Contants;

namespace BigPurpleBank.Tests
{
    public class BankingControllerTests
    {
        private readonly Mock<IBankingService> _mockBankingService;
        private readonly Mock<ILogger<BankingController>> _mockLogger;
        private readonly BankingController _controller;

        public BankingControllerTests()
        {
            _mockBankingService = new Mock<IBankingService>();
            _mockLogger = new Mock<ILogger<BankingController>>();
            _controller = new BankingController(_mockBankingService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAccounts_WithValidParams_ReturnsOk()
        {
            // Arrange
            var fakeAccounts = new ResponseBankingAccountListV2(); // Populate with mock data if needed
            _mockBankingService.Setup(s => s.GetAccountsAsync()).ReturnsAsync(fakeAccounts);

            // Act
            var result = await _controller.GetAccounts(null, OpenStatus.ALL, true, 1, 25);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(fakeAccounts, okResult.Value);
        }

        [Fact]
        public async Task GetAccounts_WithInvalidProductCategory_ReturnsBadRequest()
        {
            // Arrange
            var invalidProductCategory = (BankingProductCategory)999;

            // Act
            var result = await _controller.GetAccounts(invalidProductCategory, OpenStatus.ALL, true, 1, 25);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, objectResult.StatusCode);
            var errorList = Assert.IsType<ResponseErrorListV2>(objectResult.Value);
            Assert.Contains(errorList.Errors, e => e.Detail == "product-category");
        }

        [Fact]
        public async Task GetAccounts_WithInvalidPageSize_ReturnsBadRequest()
        {
            // Arrange
            int largePageSize = 1000;

            // Act
            var result = await _controller.GetAccounts(null, OpenStatus.ALL, true, 1, largePageSize);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(422, objectResult.StatusCode);
            var errorList = Assert.IsType<ResponseErrorListV2>(objectResult.Value);
            Assert.Contains(errorList.Errors, e => e.Code == ErrorCodes.InvalidPage);
        }

        [Fact]
        public async Task GetAccounts_WhenExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _mockBankingService.Setup(s => s.GetAccountsAsync()).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetAccounts(null, OpenStatus.ALL, true, 1, 25);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            var errorList = Assert.IsType<ResponseErrorListV2>(objectResult.Value);
            Assert.Contains(errorList.Errors, e => e.Code == ErrorCodes.InternalServerError);
        }
    }
}