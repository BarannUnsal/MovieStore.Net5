using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Delete;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Commands.Delete
{
    public class DeleteCustomerTest : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCustomerTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreayExistCustomerNameIsGiven_InvalidatOperationException_ShouldBeReturn()
        {
            DeleteCustomerCommand command = new(_context);
            command.CustomerId = 1;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Müşteri Bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShoulBeDeleted()
        {
            DeleteCustomerCommand command = new(_context);
            var customer = new Customer() { Name = "Ahmet", Surname = "Ünsal" };
            FluentActions.Invoking(() => command.Handle()).Invoke();

            customer = _context.Customers.SingleOrDefault(x => x.Name == customer.Name);
            customer.Should().NotBeNull();
            customer.Id.Should().Be(command.CustomerId);
        }
    }
}