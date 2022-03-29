using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorTest : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteDirectorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreayExistDirectorNameIsGiven_InvalidatOperationException_ShouldBeReturn()
        {
            DeleteDirectorCommand command = new(_context);
            command.DirectorId = 1;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Yazar Bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Director_ShoulBeDeleted()
        {
            DeleteDirectorCommand command = new(_context);
            var director = new Director() { Name = "Ahmet", Surname = "Ünsal" };
            FluentActions.Invoking(() => command.Handle()).Invoke();

            director = _context.Directors.SingleOrDefault(x => x.Name == director.Name);
            director.Should().NotBeNull();
            director.Id.Should().Be(command.DirectorId);
        }
    }
}