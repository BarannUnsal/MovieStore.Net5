using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Commands.Create;
using MovieStore.WebApi.Application.GenreOperations.Command.Create;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.GenreOperations.Command.Create
{
    public class CreateGenreValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            command.Model = new CreateGenreViewModel() { Name = "" };

            CreateGenreValidator validator = new CreateGenreValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(" ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            command.Model = new CreateGenreViewModel() { Name = name };

            CreateGenreValidator validator = new CreateGenreValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}