using FluentValidation;

namespace MovieStore.WebApi.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorValidator()
        {
            RuleFor(x => x.DirectorId).GreaterThan(0);
        }
    }
}