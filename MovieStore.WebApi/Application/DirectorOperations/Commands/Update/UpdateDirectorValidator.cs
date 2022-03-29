using FluentValidation;

namespace MovieStore.WebApi.Application.DirectorOperations.Commands.Update
{
    public class UpdateDirectorValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorValidator()
        {
            RuleFor(x => x.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(65);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(65);
        }
    }
}