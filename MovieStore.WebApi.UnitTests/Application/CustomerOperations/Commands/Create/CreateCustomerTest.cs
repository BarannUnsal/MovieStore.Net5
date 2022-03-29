using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Create;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Commands.Create
{
    public class CreateCustomerTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerTest(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Fact]
        public void WhenAlreadyExistCustomerNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var customer = new Customer() { Name = "Baran", Surname = " " };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            CreateCustomerViewModel model = new CreateCustomerViewModel() { Name = customer.Name };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri zaten mevcut. Yeniden ekleyemezsiniz!");
        }

        [Fact]
        public void WhenValidaInputsAreGiven_Customer_ShouldBeCreated()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            CreateCustomerViewModel model = new CreateCustomerViewModel() { Name = "Sinem", Surname = "Ünsal" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(x => x.Name == model.Name);
            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.Surname.Should().Be(model.Surname);
        }
    }
}