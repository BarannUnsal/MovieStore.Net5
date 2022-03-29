using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.GenreOperations.Queiries.GetDetails
{
    public class GetGenreDetailsTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailsTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistGenreIdIsGiven_InvalidOperationException_ShouldBeReutrn()
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(_context, _mapper);
            query.Model = new GetGenreDetailsViewModel() { Name = "Ayşe" };

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aranan film türü bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeGetted()
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(_context, _mapper);
            GetGenreDetailsViewModel model = new GetGenreDetailsViewModel() { Name = "Yaşar Kemal" };
            query.Model = model;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(x => x.Name == model.Name);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);
        }
    }
}