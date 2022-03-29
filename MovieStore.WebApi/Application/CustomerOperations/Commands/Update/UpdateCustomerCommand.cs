using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Commands.Update
{
    public class UpdateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateCustomerViewModel Model { get; set; }
        public int CustomerId { get; set; }
        public UpdateCustomerCommand(IMovieStoreDbContext context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _context.Customers.Find(CustomerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz müşteri bulunamadı!");
            }
            customer.Name = Model.Name == default ? Model.Name : customer.Name;
            customer.Surname = Model.Surname == default ? Model.Surname : customer.Surname;
            _context.SaveChanges();

        }
    }
    public class UpdateCustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}