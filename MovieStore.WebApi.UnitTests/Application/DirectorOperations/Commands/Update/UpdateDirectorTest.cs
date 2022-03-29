using System;
using System.Linq;
using FluentAssertions;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Update;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Command.Update
{
    public class UpdateDirectorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateDirectorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenAlreadExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            UpdateDirectorViewModel model = new UpdateDirectorViewModel() { Name = "Aşk" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellemek istediğiniz yönetmen bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeUpdated()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            UpdateDirectorViewModel model = new UpdateDirectorViewModel() { Name = "Aşk" };
            command.Model = model;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _context.Directors.SingleOrDefault(x => x.Name == model.Name);
            director.Should().NotBeNull();
            director.Name.Should().Be(model.Name);
        }
    }
}