using FluentValidation;

namespace MovieStore.WebApi.Application.DirectorOperations.Commands.Create
{
    public class CreateDirectorValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(65);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(65);
        }
    }
}