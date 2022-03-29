using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.MovieOperations.Command.Create
{
    public class CreateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieViewModel Model { get; set; }
        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Name == Model.Name);
            if (movie != null)
            {
                throw new InvalidOperationException("Eklemek istediğiniz film daha önceden eklenmiş. Lütfen başka bir film ekleyiniz.");
            }
            movie = _mapper.Map<Movie>(Model);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
    public class CreateMovieViewModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}