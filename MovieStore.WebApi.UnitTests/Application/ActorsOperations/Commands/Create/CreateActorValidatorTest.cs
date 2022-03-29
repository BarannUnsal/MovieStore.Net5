using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Commands.Create;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Command.Create
{
    public class CreateActorValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorViewModel() { Name = "", Surname = "2" };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(" ", " ")]
        [InlineData(" ", " ünsal")]
        [InlineData("Baran", " ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorViewModel() { Name = name, Surname = surname };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}