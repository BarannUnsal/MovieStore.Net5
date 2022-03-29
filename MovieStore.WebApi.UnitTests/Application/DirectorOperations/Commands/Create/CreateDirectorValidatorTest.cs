using FluentAssertions;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Create;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Commands.Create
{
    public class CreateDirectorValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorViewModel() { Name = "", Surname = "2" };

            CreateDirectorValidator validator = new CreateDirectorValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(" ", " ")]
        [InlineData(" ", " ünsal")]
        [InlineData("Baran", " ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorViewModel() { Name = name, Surname = surname };

            CreateDirectorValidator validator = new CreateDirectorValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}