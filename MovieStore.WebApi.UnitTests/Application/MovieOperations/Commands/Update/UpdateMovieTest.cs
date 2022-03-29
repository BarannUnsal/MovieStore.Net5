using System;
using System.Linq;
using FluentAssertions;
using MovieStore.WebApi.Application.MovieOperations.Command.Update;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Command.Update
{
    public class UpdateMovieTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateMovieTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenAlreadExistGMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, null);
            UpdateMovieViewModel model = new UpdateMovieViewModel() { Name = "Aşk" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellemek istediğiniz film bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeUpdated()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, null);
            UpdateMovieViewModel model = new UpdateMovieViewModel() { Name = "Aşk" };
            command.Model = model;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            var movie = _context.Movies.SingleOrDefault(x => x.Name == model.Name);
            movie.Should().NotBeNull();
            movie.Name.Should().Be(model.Name);
        }
    }
}