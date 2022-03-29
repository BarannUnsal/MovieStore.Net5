using System;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.UnitTests.TestsSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            //Movie
            context.Movies.AddRange(
                new Movie
                {
                    Name = "Lort Of The Rings: Fellowship of The Ring",
                    PublishDate = new DateTime(2001, 21, 21),
                    GenreId = 1,
                    Price = 30,
                    DirectorId = 1
                },
                new Movie
                {
                    Name = "Pirates of the Caribbean: The Curse of the Black Pearl",
                    PublishDate = new DateTime(2003, 10, 29),
                    GenreId = 2,
                    Price = 25,
                    DirectorId = 2
                },
                new Movie
                {
                    Name = "Love And Prejudice",
                    PublishDate = new DateTime(2006, 02, 03),
                    GenreId = 4,
                    Price = 20,
                    DirectorId = 3
                },
                new Movie
                {
                    Name = "Shaun of the Dead",
                    PublishDate = new DateTime(2004, 04, 09),
                    GenreId = 3,
                    Price = 15,
                    DirectorId = 4
                }
            );
        }
    }
}

