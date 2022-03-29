using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Commands.Update;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Command.Update
{
    public class UpdateActorValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            UpdateActorCommand query = new UpdateActorCommand(null);
            query.Model = new UpdateActorViewModel() { Name = "" };

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturnError(int id)
        {
            UpdateActorCommand query = new UpdateActorCommand(null);
            query.ActorId = id;

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}