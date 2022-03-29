using FluentValidation;

namespace MovieStore.WebApi.Application.MovieOperations.Command.Delete
{
    public class DeleteMovieValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}