using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Queiries.GetDetails
{
    public class GetActorDetailTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorDetailTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReutrn()
        {
            GetActorDetialsQuery query = new GetActorDetialsQuery(_context, _mapper);
            query.Model = new GetActorDetailsViewModel() { Name = "Ayşe", Surname = "Ünsal" };

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aranan Aktör bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeGetted()
        {
            GetActorDetialsQuery query = new GetActorDetialsQuery(_context, _mapper);
            GetActorDetailsViewModel model = new GetActorDetailsViewModel() { Name = "Yaşar Kemal", Surname = "Unsal" };
            query.Model = model;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(x => x.Name == model.Name);
            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.Surname.Should().Be(model.Surname);
        }
    }
}