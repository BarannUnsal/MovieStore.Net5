using FluentValidation;

namespace MovieStore.WebApi.Application.GenreOperations.Command.Delete
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}