using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Mapper;

namespace MovieStore.WebApi.UnitTests.TestsSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDb").Options;
            Context = new MovieStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddActors();
            Context.AddCustomers();
            Context.AddDirectors();
            Context.AddGenres();
            Context.AddMovies();

            Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}