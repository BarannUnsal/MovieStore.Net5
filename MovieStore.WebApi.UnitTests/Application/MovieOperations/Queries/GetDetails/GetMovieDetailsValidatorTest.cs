using FluentAssertions;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetails;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Queiries.GetDetails
{
    public class GetMovieDetailsValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn()
        {
            GetMovieDetailsQuery query = new GetMovieDetailsQuery(null, null);
            query.Model = new GetMovieDetailsViewModel() { Name = "" };
            GetMovieDetailsValidator validator = new GetMovieDetailsValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetMovieDetailsQuery query = new GetMovieDetailsQuery(null, null);
            query.MovieId = id;

            GetMovieDetailsValidator validator = new GetMovieDetailsValidator();

            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}