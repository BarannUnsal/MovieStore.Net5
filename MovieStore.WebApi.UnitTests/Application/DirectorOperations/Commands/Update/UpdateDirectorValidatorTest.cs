using FluentAssertions;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Update;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Command.Update
{
    public class UpdateDirectorValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAlreadyExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.Model = new UpdateDirectorViewModel() { Name = "" };

            UpdateDirectorValidator validator = new UpdateDirectorValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenAlreadyExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturnError(int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.DirectorId = id;

            UpdateDirectorValidator validator = new UpdateDirectorValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}