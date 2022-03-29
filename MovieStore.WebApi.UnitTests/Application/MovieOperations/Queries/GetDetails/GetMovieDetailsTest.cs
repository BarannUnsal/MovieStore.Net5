using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetails;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.MovieOperations.Queiries.GetDetails
{
    public class GetMovieDetailsTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMovieDetailsTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistGenreIdIsGiven_InvalidOperationException_ShouldBeReutrn()
        {
            GetMovieDetailsQuery query = new GetMovieDetailsQuery(_context, _mapper);
            query.Model = new GetMovieDetailsViewModel() { Name = "Ayşe" };

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aranan film bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeGetted()
        {
            GetMovieDetailsQuery query = new GetMovieDetailsQuery(_context, _mapper);
            GetMovieDetailsViewModel model = new GetMovieDetailsViewModel() { Name = "Yaşar Kemal" };
            query.Model = model;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var movie = _context.Movies.SingleOrDefault(x => x.Name == model.Name);
            movie.Should().NotBeNull();
            movie.Name.Should().Be(model.Name);
        }
    }
}