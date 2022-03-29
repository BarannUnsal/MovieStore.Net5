using System;
using System.Linq;
using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Commands.Update;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Command.Update
{
    public class UpdateActorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateActorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenAlreadExistActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateActorCommand query = new UpdateActorCommand(_context);
            UpdateActorViewModel model = new UpdateActorViewModel() { Name = "Aşk" };
            query.Model = model;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellemek istediğiniz aktör bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeUpdated()
        {
            UpdateActorCommand query = new UpdateActorCommand(_context);
            UpdateActorViewModel model = new UpdateActorViewModel() { Name = "Aşk" };
            query.Model = model;
            FluentActions.Invoking(() => query.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(x => x.Name == model.Name);
            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
        }
    }
}