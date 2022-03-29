using System;
using System.Linq;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.ActorOperations.Commands.Delete
{
    public class DeleteActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int ActorId { get; set; }
        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor == null)
            {
                throw new InvalidOperationException("Silinecek Aktör Bulunamadı!");
            }
            if (actor.MovieActors.Any())
            {
                actor.isActive = false;
            }
            else
            {
                _context.Actors.Remove(actor);
            }
            _context.SaveChanges();
        }
    }
}