using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.GenreOperations.Command.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.GenreOperations.Command.Delete
{
    public class DeleteGenreTest : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteGenreTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreayExistGenreNameIsGiven_InvalidatOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new(_context);
            command.GenreId = 1;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek film türü Bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShoulBeDeleted()
        {
            DeleteGenreCommand command = new(_context);
            var genre = new Genre() { Name = "Ahmet" };
            FluentActions.Invoking(() => command.Handle()).Invoke();

            genre = _context.Genres.SingleOrDefault(x => x.Name == genre.Name);
            genre.Should().NotBeNull();
            genre.Id.Should().Be(command.GenreId);
        }
    }
}