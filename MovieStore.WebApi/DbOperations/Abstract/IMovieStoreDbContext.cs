using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.DbOperations.Abstract
{
    public interface IMovieStoreDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Customer> Customers { get; set; }

        int SaveChanges();
    }
}