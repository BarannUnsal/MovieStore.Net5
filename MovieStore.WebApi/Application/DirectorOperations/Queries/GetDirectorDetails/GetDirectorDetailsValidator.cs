using FluentValidation;

namespace MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailsValidator : AbstractValidator<GetDirectorDetailsQuery>
    {
        public GetDirectorDetailsValidator()
        {
            RuleFor(x => x.DirectorId).GreaterThan(0);
        }
    }
}