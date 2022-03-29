using FluentValidation;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Commands.Update
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(65);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(65);
        }
    }
}