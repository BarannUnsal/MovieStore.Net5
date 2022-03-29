using FluentAssertions;
using MovieStore.WebApi.Application.GenreOperations.Command.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.GenreOperations.Command.Delete
{
    public class DeleteGenreValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteGenreValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenInvalidaInputAreGiven_Validator_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            DeleteGenreValidator validator = new DeleteGenreValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterOrEqualTo(0);
        }
        [Theory]
        [InlineData(" ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreValidator validator = new DeleteGenreValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}