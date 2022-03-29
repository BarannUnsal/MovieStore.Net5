using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Commands.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Command.Delete
{
    public class DeleteActorTest : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteActorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreayExistActorNameIsGiven_InvalidatOperationException_ShouldBeReturn()
        {
            DeleteActorCommand command = new(_context);
            command.ActorId = 1;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Aktör Bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShoulBeDeleted()
        {
            DeleteActorCommand command = new(_context);
            var actor = new Actor() { Name = "Ahmet", Surname = "Ünsal" };
            FluentActions.Invoking(() => command.Handle()).Invoke();

            actor = _context.Actors.SingleOrDefault(x => x.Name == actor.Name);
            actor.Should().NotBeNull();
            actor.Id.Should().Be(command.ActorId);
        }
    }
}