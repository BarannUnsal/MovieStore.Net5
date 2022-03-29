using FluentValidation;

namespace MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetails
{
    public class GetGenreDetailsValidator : AbstractValidator<GetGenreDetailsQuery>
    {
        public GetGenreDetailsValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}