using FluentAssertions;
using MovieStore.WebApi.Application.MovieOperations.Command.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Command.Delete
{
    public class DeleteMovieValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteMovieValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenInvalidaInputAreGiven_Validator_ShouldBeReturn()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            DeleteMovieValidator validator = new DeleteMovieValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterOrEqualTo(0);
        }
        [Theory]
        [InlineData(" ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;
            DeleteMovieValidator validator = new DeleteMovieValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}