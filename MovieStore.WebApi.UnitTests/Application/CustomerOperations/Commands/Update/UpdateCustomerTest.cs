using System;
using System.Linq;
using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Update;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Command.Update
{
    public class UpdateCustomerTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateCustomerTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenAlreadExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            UpdateCustomerViewModel model = new UpdateCustomerViewModel() { Name = "Aşk" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellemek istediğiniz müşteri bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeUpdated()
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            UpdateCustomerViewModel model = new UpdateCustomerViewModel() { Name = "Aşk" };
            command.Model = model;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            var customer = _context.Customers.SingleOrDefault(x => x.Name == model.Name);
            customer.Should().NotBeNull();
            customer.Name.Should().Be(model.Name);
        }
    }
}