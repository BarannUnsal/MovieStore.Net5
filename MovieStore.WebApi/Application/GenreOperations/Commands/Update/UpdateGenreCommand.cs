using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.GenreOperations.Command.Update
{
    public class UpdateGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateGenreViewModel Model { get; set; }
        public int GenreId { get; set; }
        public UpdateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz film türü bulunamadı!");
            }
            genre.Name = Model.Name == default ? Model.Name : genre.Name;
            genre.isActive = Model.isActive == default ? Model.isActive : genre.isActive;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}