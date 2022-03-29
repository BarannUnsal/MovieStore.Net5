using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Delete;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Update;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Commands.Delete
{
    public class DeleteCustomerValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteCustomerValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenInvalidaInputAreGiven_Validator_ShouldBeReturn()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            DeleteCustomerValidator validator = new DeleteCustomerValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterOrEqualTo(0);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;
            DeleteCustomerValidator validator = new DeleteCustomerValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}