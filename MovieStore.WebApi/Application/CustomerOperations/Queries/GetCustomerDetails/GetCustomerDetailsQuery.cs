using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerDetailsViewModel Model { get; set; }
        public int CustomerId { get; set; }
        public GetCustomerDetailsQuery(IMovieStoreDbContext context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetCustomerDetailsViewModel Handle()
        {
            var customer = _context.Customers.Include(x => x.CustomerGenres).ThenInclude(x => x.Genre);
            if (customer == null)
            {
                throw new InvalidOperationException("Aradığınız müşteri bilgileri bulunamadı!");
            }
            var viewModel = _mapper.Map<GetCustomerDetailsViewModel>(customer);
            return viewModel;
        }
    }
    public class GetCustomerDetailsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> FavGenres { get; set; }
    }
}