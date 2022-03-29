using FluentValidation;

namespace MovieStore.WebApi.Application.GenreOperations.Command.Create
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(50);
        }
    }
}