using FluentAssertions;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteDirectorValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenInvalidaInputAreGiven_Validator_ShouldBeReturn()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            DeleteDirectorValidator validator = new DeleteDirectorValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterOrEqualTo(0);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            DeleteDirectorValidator validator = new DeleteDirectorValidator();

            var errors = validator.Validate(command);

            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}