using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Queiries.GetDetails
{
    public class GetActorDetailValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn()
        {
            GetActorDetialsQuery query = new GetActorDetialsQuery(null, null);
            query.Model = new GetActorDetailsViewModel() { Name = "", Surname = " " };
            GetActorDetialsValidator validator = new GetActorDetialsValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetActorDetialsQuery query = new GetActorDetialsQuery(null, null);
            query.ActorId = id;

            GetActorDetialsValidator validator = new GetActorDetialsValidator();

            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}