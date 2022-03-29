using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Update;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Command.Update
{
    public class UpdateCustomerValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAlreadyExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(null);
            command.Model = new UpdateCustomerViewModel() { Name = "" };

            UpdateCustomerValidator validator = new UpdateCustomerValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenAlreadyExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReturnError(int id)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(null);
            command.CustomerId = id;

            UpdateCustomerValidator validator = new UpdateCustomerValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}