using System;
using FluentValidation;

namespace MovieStore.WebApi.Application.MovieOperations.Command.Create
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.PublishDate).LessThan(DateTime.Now.Date);
        }
    }
}