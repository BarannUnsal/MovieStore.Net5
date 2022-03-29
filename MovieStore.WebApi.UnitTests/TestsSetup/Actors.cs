using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.UnitTests.TestsSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {

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
        }
    }
}