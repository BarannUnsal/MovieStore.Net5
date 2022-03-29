using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.GenreOperations.Command.Delete;
using MovieStore.WebApi.Application.MovieOperations.Command.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Command.Delete
{
    public class DeleteMovieTest : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteMovieTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreayExistMovieNameIsGiven_InvalidatOperationException_ShouldBeReturn()
        {
            DeleteMovieCommand command = new(_context);
            command.MovieId = 1;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Film Bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShoulBeDeleted()
        {
            DeleteMovieCommand command = new(_context);
            var movie = new Movie() { Name = "Ahmet" };
            FluentActions.Invoking(() => command.Handle()).Invoke();

            movie = _context.Movies.SingleOrDefault(x => x.Name == movie.Name);
            movie.Should().NotBeNull();
            movie.Id.Should().Be(command.MovieId);
        }
    }
}