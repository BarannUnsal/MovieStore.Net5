using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Create;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Commands.Create
{
    public class CreateCustomerValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerViewModel() { Name = "", Surname = "2" };

            CreateCustomerValidator validator = new CreateCustomerValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(" ", " ")]
        [InlineData(" ", " ünsal")]
        [InlineData("Baran", " ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerViewModel() { Name = name, Surname = surname };

            CreateCustomerValidator validator = new CreateCustomerValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}