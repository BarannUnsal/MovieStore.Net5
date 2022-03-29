using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Commands.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Command.Delete
{
    public class DeleteActorValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteActorValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenInvalidaInputAreGiven_Validator_ShouldBeReturn()
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterOrEqualTo(0);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}