using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Create;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Create;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Commands.Create
{
    public class CreateDirectorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorTest(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Fact]
        public void WhenAlreadyExistDirectorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var customer = new Customer() { Name = "Baran", Surname = " " };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            CreateDirectorViewModel model = new CreateDirectorViewModel() { Name = customer.Name };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Varolan yönetmeni yeniden ekleyemezsiniz!");
        }

        [Fact]
        public void WhenValidaInputsAreGiven_Director_ShouldBeCreated()
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            CreateDirectorViewModel model = new CreateDirectorViewModel() { Name = "Sinem", Surname = "Ünsal" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _context.Directors.SingleOrDefault(x => x.Name == model.Name);
            director.Should().NotBeNull();
            director.Name.Should().Be(model.Name);
            director.Surname.Should().Be(model.Surname);
        }
    }
}