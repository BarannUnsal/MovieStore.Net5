using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Commands.Create
{
    public class CreateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerViewModel Model { get; set; }
        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (customer != null)
            {
                throw new InvalidOperationException("Girmek istediğiniz müşteri bilgileri ile daha önceden bir kimlik oluşturulmuş. Lütfen yeni bir kimlik oluşturunuz!");
            }
            customer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
    public class CreateCustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}