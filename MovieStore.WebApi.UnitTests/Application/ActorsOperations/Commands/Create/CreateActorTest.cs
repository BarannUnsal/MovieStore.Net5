using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.ActorOperations.Commands.Create;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.ActorsOperations.Command.Create
{
    public class CreateActorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorTest(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var actor = new Actor() { Name = "Baran", Surname = " " };
            _context.Actors.Add(actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            CreateActorViewModel model = new CreateActorViewModel() { Name = actor.Name };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Varolan aktörü yeniden ekleyemezsiniz!");
        }

        [Fact]
        public void WhenValidaInputsAreGiven_Actor_ShouldBeCreated()
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            CreateActorViewModel model = new CreateActorViewModel() { Name = "Sinem", Surname = "Ünsal" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(x => x.Name == model.Name);
            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.Surname.Should().Be(model.Surname);
        }
    }
}