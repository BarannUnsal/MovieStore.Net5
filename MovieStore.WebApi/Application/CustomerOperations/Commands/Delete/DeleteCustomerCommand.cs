using System;
using System.Linq;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Commands.Delete
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int CustomerId { get; set; }
        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Silmek istediğiniz müşteri bilgileri bulunamadı!");
            }
            _context.Customers.Remove(customer);
            customer.isActive = false;
            _context.SaveChanges();
        }
    }
}