using FluentValidation;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Commands.Create
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(65);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(65);
        }
    }
}