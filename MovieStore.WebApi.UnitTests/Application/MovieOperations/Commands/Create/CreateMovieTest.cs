using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.MovieOperations.Command.Create;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Command.Create
{
    public class CreateMovieTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieTest(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var movie = new Movie() { Name = "Baran" };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            CreateMovieViewModel model = new CreateMovieViewModel() { Name = movie.Name };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film zaten mevcut. Yeniden ekleyemezsiniz!");
        }

        [Fact]
        public void WhenValidaInputsAreGiven_Movie_ShouldBeCreated()
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            CreateMovieViewModel model = new CreateMovieViewModel() { Name = "Sinem" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var movie = _context.Movies.SingleOrDefault(x => x.Name == model.Name);
            movie.Should().NotBeNull();
            movie.Name.Should().Be(model.Name);
        }
    }
}