using FluentValidation;

namespace MovieStore.WebApi.Application.GenreOperations.Command.Update
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(65);
        }
    }
}