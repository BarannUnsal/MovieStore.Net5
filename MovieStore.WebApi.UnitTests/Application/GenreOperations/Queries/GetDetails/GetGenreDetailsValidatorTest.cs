using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.GenreOperations.Queiries.GetDetails
{
    public class GetGenreDetailsValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn()
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(null, null);
            query.Model = new GetGenreDetailsViewModel() { Name = "" };
            GetGenreDetailsValidator validator = new GetGenreDetailsValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(null, null);
            query.GenreId = id;

            GetGenreDetailsValidator validator = new GetGenreDetailsValidator();

            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}