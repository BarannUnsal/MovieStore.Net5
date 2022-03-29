using FluentValidation;

namespace MovieStore.WebApi.Application.ActorOperations.Commands.Update
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(65);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(65);
        }

        public object ValidateAnThrow { get; internal set; }
    }
}