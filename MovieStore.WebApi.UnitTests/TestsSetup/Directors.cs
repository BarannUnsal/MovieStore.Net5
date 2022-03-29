using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.UnitTests.TestsSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
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
        }
    }
}