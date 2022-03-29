using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.GenreOperations.Command.Create
{
    public class CreateGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreViewModel Model { get; set; }
        public CreateGenreCommand(IMovieStoreDbContext context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre != null)
            {
                throw new InvalidOperationException("Eklemek istediğiniz film türü mevcut!");
            }
            genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
    public class CreateGenreViewModel
    {
        public string Name { get; set; }
    }
}