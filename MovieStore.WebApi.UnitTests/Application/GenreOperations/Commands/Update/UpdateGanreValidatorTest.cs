using FluentAssertions;
using MovieStore.WebApi.Application.GenreOperations.Command.Update;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.GenreOperations.Command.Update
{
    public class UpdateGanreValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null, null);
            command.Model = new UpdateGenreViewModel() { Name = " " };

            UpdateGenreValidator validator = new UpdateGenreValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturnError(int id)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null, null);
            command.GenreId = id;

            UpdateGenreValidator validator = new UpdateGenreValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}