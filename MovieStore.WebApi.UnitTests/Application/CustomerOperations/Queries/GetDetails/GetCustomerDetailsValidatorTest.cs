using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomerDetails;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Queiries.GetDetails
{
    public class GetCustomerDetailsValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturn()
        {
            GetCustomerDetailsQuery query = new GetCustomerDetailsQuery(null, null);
            query.Model = new GetCustomerDetailsViewModel() { Name = "", Surname = " " };
            GetCustomerDetailsValidator validator = new GetCustomerDetailsValidator();
            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetCustomerDetailsQuery query = new GetCustomerDetailsQuery(null, null);
            query.CustomerId = id;

            GetCustomerDetailsValidator validator = new GetCustomerDetailsValidator();

            var errors = validator.Validate(query);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}