using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenreQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetGenreViewModel> Handle()
        {
            var genre = _context.Genres.Include(x => x.GenreCustomers).ThenInclude(x => x.Customer).Include(x => x.GenreMovies).ToList().OrderBy(x => x.Id);
            List<GetGenreViewModel> viewModels = _mapper.Map<List<GetGenreViewModel>>(genre);
            return viewModels;
        }
    }
    public class GetGenreViewModel
    {
        public string Name { get; set; }
        public List<string> Customers { get; set; }
        public List<string> GenreMovies { get; set; }
    }
}