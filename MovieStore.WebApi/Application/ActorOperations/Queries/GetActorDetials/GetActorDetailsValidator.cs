using FluentValidation;

namespace MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials
{
    public class GetActorDetialsValidator : AbstractValidator<GetActorDetialsQuery>
    {
        public GetActorDetialsValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(65);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(65);
        }
    }
}