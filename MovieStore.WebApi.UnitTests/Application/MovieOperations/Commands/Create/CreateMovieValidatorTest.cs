using FluentAssertions;
using MovieStore.WebApi.Application.MovieOperations.Command.Create;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Command.Create
{
    public class CreateGenreValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieViewModel() { Name = "" };

            CreateMovieValidator validator = new CreateMovieValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(" ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieViewModel() { Name = name };

            CreateMovieValidator validator = new CreateMovieValidator();
            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}