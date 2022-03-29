using System;
using System.Linq;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.MovieOperations.Command.Delete
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int MovieId { get; set; }
        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException("Silmek istediğiniz film bulunamadı!");
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}