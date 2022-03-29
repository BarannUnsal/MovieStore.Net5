using FluentAssertions;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Update;
using MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectorDetails;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Queiries.GetDetails
{
    public class GetDirectorDetailsValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAlreadyExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(null);
            query.Model = new GetDirectorDetailsViewModel() { Name = "" };

            GetDirectorDetailsValidator validator = new GetDirectorDetailsValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenAlreadyExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturnError(int id)
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(null);
            query.DirectorId = id;

            GetDirectorDetailsValidator validator = new GetDirectorDetailsValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}