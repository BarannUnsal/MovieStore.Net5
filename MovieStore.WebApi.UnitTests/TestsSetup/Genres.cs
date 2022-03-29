using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.UnitTests.TestsSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
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
        }
    }
}