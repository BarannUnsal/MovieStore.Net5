using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int DirectorId { get; set; }

        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var director = _context.Directors.Include(x => x.Movies).SingleOrDefault(x => x.Id == DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Silmek istediğiniz yönetmen bulunamadı!");
            }
            _context.Directors.Remove(director);
            director.isActive = false;
            _context.SaveChanges();
        }
    }
}