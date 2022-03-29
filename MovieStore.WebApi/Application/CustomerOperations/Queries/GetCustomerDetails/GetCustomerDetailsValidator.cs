using FluentValidation;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsValidator : AbstractValidator<GetCustomerDetailsQuery>
    {
        public GetCustomerDetailsValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
        }
    }
}