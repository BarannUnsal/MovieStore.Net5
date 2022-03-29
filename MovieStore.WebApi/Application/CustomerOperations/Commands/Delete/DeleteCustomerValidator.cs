using FluentValidation;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Commands.Delete
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
        }
    }
}