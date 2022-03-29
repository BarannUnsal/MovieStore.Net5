using System;
using System.Linq;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.GenreOperations.Command.Delete
{
    public class DeleteGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int GenreId { get; set; }
        public DeleteGenreCommand(IMovieStoreDbContext context = null)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException("Silmek istediğiniz film türü bulunamadı!");
            }
            _context.Genres.Remove(genre);
            genre.isActive = false;
            _context.SaveChanges();
        }
    }
}