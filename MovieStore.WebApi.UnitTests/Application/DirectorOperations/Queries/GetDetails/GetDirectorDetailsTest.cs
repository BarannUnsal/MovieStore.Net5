using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectorDetails;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.UnitTests.TestsSetup;
using Xunit;

namespace MovieStore.WebApi.UnitTests.Application.DirectorOperations.Queiries.GetDetails
{
    public class GetDirectorDetailsTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorDetailsTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistDirectorIdIsGiven_InvalidOperationException_ShouldBeReutrn()
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(_context, _mapper);
            query.Model = new GetDirectorDetailsViewModel() { Name = "Ayşe", Surname = "Ünsal" };

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aradğınız yönetmen bulunamadı!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeGetted()
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(_context, _mapper);
            GetDirectorDetailsViewModel model = new GetDirectorDetailsViewModel() { Name = "Yaşar Kemal", Surname = "Unsal" };
            query.Model = model;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var director = _context.Directors.SingleOrDefault(x => x.Name == model.Name);
            director.Should().NotBeNull();
            director.Name.Should().Be(model.Name);
            director.Surname.Should().Be(model.Surname);
        }
    }
}