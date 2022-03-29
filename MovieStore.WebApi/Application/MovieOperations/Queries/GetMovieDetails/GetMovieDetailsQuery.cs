using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetails
{
    public class GetMovieDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public GetMovieDetailsViewModel Model { get; set; }
        public GetMovieDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetMovieDetailsViewModel Handle()
        {
            var movie = _context.Movies.Include(x => x.Director).Include(x => x.Genre).Include(x => x.MovieActor).ThenInclude(x => x.Actor).SingleOrDefault(x => x.GenreId == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException("Aradığınız film bulunamadı1");
            }
            var viewModel = _mapper.Map<GetMovieDetailsViewModel>(movie);
            return viewModel;
        }
    }
    public class GetMovieDetailsViewModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public List<string> MovieActors { get; set; }

    }
}