using MovieStore.WebApi.DbOperations.Concrete;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.UnitTests.TestsSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
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
}