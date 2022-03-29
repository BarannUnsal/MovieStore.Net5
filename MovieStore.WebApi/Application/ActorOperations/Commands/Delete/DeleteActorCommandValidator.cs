using FluentValidation;

namespace MovieStore.WebApi.Application.ActorOperations.Commands.Delete
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
        }
    }
}