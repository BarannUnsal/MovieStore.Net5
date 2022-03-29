using System;
using FluentValidation;
using MovieStore.WebApi.Application.MovieOperations.Command.Update;

namespace MovieStore.WebApi.Application.MovieOperations.Command.Update
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.PublishDate).LessThan(DateTime.Now.Date);
        }
    }
}