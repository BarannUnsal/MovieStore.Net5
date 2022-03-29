using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetails
{
    public class GetGenreDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public GetGenreDetailsViewModel Model { get; set; }
        public GetGenreDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetGenreDetailsViewModel Handle()
        {
            var genre = _context.Genres.Include(x => x.GenreCustomers).ThenInclude(x => x.Customer).Include(x => x.GenreMovies).SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException("Aradığınız film türü bulunamadı!");
            }
            GetGenreDetailsViewModel viewModel = _mapper.Map<GetGenreDetailsViewModel>(genre);
            return viewModel;
        }
    }
    public class GetGenreDetailsViewModel
    {
        public string Name { get; set; }
        public string isActive { get; set; }
        public int HowManyCustomerFav { get; set; }
        public List<string> Customers { get; set; }
        public List<string> GenreMovies { get; set; }
    }
}