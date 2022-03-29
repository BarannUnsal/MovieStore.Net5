using FluentAssertions;
using MovieStore.WebApi.Application.GenreOperations.Command.Update;
using MovieStore.WebApi.Application.MovieOperations.Command.Update;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Command.Update
{
    public class UpdateMovieValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(null, null);
            command.Model = new UpdateMovieViewModel() { Name = " " };

            UpdateMovieValidator validator = new UpdateMovieValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturnError(int id)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(null, null);
            command.MovieId = id;

            UpdateMovieValidator validator = new UpdateMovieValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}