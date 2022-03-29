using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomerDetails;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.CustomerOperations.Queiries.GetDetails
{
    public class GetCustomerDetailsTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerDetailsTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReutrn()
        {
            GetCustomerDetailsQuery query = new GetCustomerDetailsQuery(_context, _mapper);
            query.Model = new GetCustomerDetailsViewModel() { Name = "Ayşe", Surname = "Ünsal" };

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aranan Müşteri bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeGetted()
        {
            GetCustomerDetailsQuery query = new GetCustomerDetailsQuery(_context, _mapper);
            GetCustomerDetailsViewModel model = new GetCustomerDetailsViewModel() { Name = "Yaşar Kemal", Surname = "Unsal" };
            query.Model = model;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var customer = _context.Customers.SingleOrDefault(x => x.Name == model.Name);
            customer.Should().NotBeNull();
            customer.Name.Should().Be(model.Name);
            customer.Surname.Should().Be(model.Surname);
        }
    }
}