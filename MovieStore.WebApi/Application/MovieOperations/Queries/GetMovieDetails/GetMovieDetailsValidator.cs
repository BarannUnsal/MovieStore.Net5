using FluentValidation;

namespace MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetails
{
    public class GetMovieDetailsValidator : AbstractValidator<GetMovieDetailsQuery>
    {
        public GetMovieDetailsValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}