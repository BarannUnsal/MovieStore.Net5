using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetMovieViewModel> Handle()
        {
            var movie = _context.Movies.Include(x => x.Director).Include(x => x.Genre).Include(x => x.MovieActor).ThenInclude(x => x.Actor).ToList().OrderBy(x => x.Id);
            List<GetMovieViewModel> viewModels = _mapper.Map<List<GetMovieViewModel>>(movie);
            return viewModels;
        }
    }
    public class GetMovieViewModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public List<string> MovieActors { get; set; }
    }
}