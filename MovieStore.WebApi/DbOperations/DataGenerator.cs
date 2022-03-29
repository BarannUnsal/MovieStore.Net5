using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
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
                //Actor
                context.Actors.AddRange(
                    new Actor
                    {
                        Name = "Viggo",
                        Surname = "Mortansen",
                        isActive = true
                    },//lotr
                     new Actor
                     {
                         Name = "Elijah",
                         Surname = "Wood",
                         isActive = true
                     },//lotr
                    new Actor
                    {
                        Name = "Sean",
                        Surname = "Astin",
                        isActive = true
                    },//lotr
                    new Actor
                    {
                        Name = "Ian",
                        Surname = "McKellen",
                        isActive = true
                    },//lotr
                    new Actor
                    {
                        Name = "Orlando",
                        Surname = "Bloom",
                        isActive = true
                    },//lotr , pirates
                    new Actor
                    {
                        Name = "Johnny",
                        Surname = "Deep",
                        isActive = true
                    },//pirates
                    new Actor
                    {
                        Name = "Keira",
                        Surname = "Knightley",
                        isActive = true
                    },//pirates, love 
                    new Actor
                    {
                        Name = "Matthew",
                        Surname = "Macfadyen",
                        isActive = true
                    },//love and prejudice
                     new Actor
                     {
                         Name = "Rosamund",
                         Surname = "Pike",
                         isActive = true
                     },//rejudice
                     new Actor
                     {
                         Name = "Simon",
                         Surname = "Pegg",
                         isActive = true
                     }, //shaun 
                     new Actor
                     {
                         Name = "Nick",
                         Surname = "Frost",
                         isActive = true
                     }, //shaun
                     new Actor
                     {
                         Name = "Edgar",
                         Surname = "Wright",
                         isActive = true
                     }//shaun
                );
                //Director
                context.Directors.AddRange(
                    new Director
                    {
                        Name = "Peter",
                        Surname = "Jackson",
                        isActive = true
                    },
                    new Director
                    {
                        Name = "Gore",
                        Surname = "Verbinski",
                        isActive = true
                    },
                     new Director
                     {
                         Name = "Joe",
                         Surname = "Wright",
                         isActive = true
                     },
                     new Director
                     {
                         Name = "Edgar",
                         Surname = "Wright",
                         isActive = true
                     }
                );
                //Genre
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Aksiyon"
                    },
                    new Genre
                    {
                        Name = "Macera"
                    },
                    new Genre
                    {
                        Name = "Komedi"
                    },
                    new Genre
                    {
                        Name = "Romantik"
                    }
                );
                //Customer
                context.Customers.AddRange(
                  new Customer
                  {
                      Name = "Baran",
                      Surname = "Ünsal",
                      isActive = true
                  },
                  new Customer
                  {
                      Name = "Sinem",
                      Surname = "Değirmenci",
                      isActive = true
                  },
                  new Customer
                  {
                      Name = "Ada",
                      Surname = "Phlip",
                      isActive = false
                  }
                );
            }
        }
        private static MovieActor[] MovieActors =
        {
            //LORT
            new MovieActor(){ MovieId = 1, ActorId = 1},
            new MovieActor(){ MovieId = 1, ActorId = 2},
            new MovieActor(){ MovieId = 1, ActorId = 3},
            new MovieActor(){ MovieId = 1, ActorId = 4},
            new MovieActor(){ MovieId = 1, ActorId = 5},
            //Pirates
            new MovieActor(){ MovieId = 2, ActorId = 5},
            new MovieActor(){ MovieId = 2, ActorId = 6},
            new MovieActor(){ MovieId = 2, ActorId = 7},
            //Love And 
            new MovieActor(){ MovieId = 3, ActorId = 7},
            new MovieActor(){ MovieId = 3, ActorId = 8},
            new MovieActor(){ MovieId = 3, ActorId = 9},
            //Shaun
            new MovieActor(){ MovieId = 4, ActorId = 10},
            new MovieActor(){ MovieId = 4, ActorId = 11},
            new MovieActor(){ MovieId = 4, ActorId = 12}
        };
    }
}