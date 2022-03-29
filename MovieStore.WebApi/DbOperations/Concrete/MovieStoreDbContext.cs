using System;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.DbOperations.Concrete
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public object ActorsSingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}