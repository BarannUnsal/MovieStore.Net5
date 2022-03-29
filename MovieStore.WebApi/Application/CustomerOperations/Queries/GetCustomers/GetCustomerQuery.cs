using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomers
{
    public class GetCustomerQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerQuery(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public List<GetCustomerViewModel> Handle()
        {
            var customer = _context.Customers.Include(x => x.CustomerGenres).ThenInclude(x => x.Genre).ToList().OrderBy(x => x.Id);
            var viewModel = _mapper.Map<List<GetCustomerViewModel>>(customer);
            return viewModel;
        }

    }
    public class GetCustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> FavGenres { get; set; }
    }
}