using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.ActorOperations.Queries.GetActors
{
    public class GetActorQuery
    {
        private readonly IMovieStoreDbContext _context;
        public GetActorViewModel Model { get; set; }
        public GetActorQuery(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public List<GetActorViewModel> Handle()
        {
            var actor = _context.Actors.Include(x => x.MovieActors).ThenInclude(x => x.Movie).ToList().OrderBy(x => x.Id);
            List<GetActorViewModel> viewModel = new List<GetActorViewModel>();
            return viewModel;
        }
    }
    public class GetActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> Movies { get; set; }
    }
}