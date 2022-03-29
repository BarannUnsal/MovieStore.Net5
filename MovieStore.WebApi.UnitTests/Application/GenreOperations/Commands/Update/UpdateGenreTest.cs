using System;
using System.Linq;
using FluentAssertions;
using MovieStore.WebApi.Application.GenreOperations.Command.Update;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.GenreOperations.Command.Update
{
    public class UpdateGenreTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateGenreTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenAlreadExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, null);
            UpdateGenreViewModel model = new UpdateGenreViewModel() { Name = "Aşk" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellemek istediğiniz film türü bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeUpdated()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, null);
            UpdateGenreViewModel model = new UpdateGenreViewModel() { Name = "Aşk" };
            command.Model = model;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(x => x.Name == model.Name);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);
        }
    }
}