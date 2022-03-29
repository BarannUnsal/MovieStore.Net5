using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.MovieOperations.Command.Update
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateMovieViewModel Model { get; set; }
        public int MovieId { get; set; }
        public UpdateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz film bulunamadı!");
            }
            movie.Name = Model.Name == default ? Model.Name : movie.Name;
            movie.PublishDate = Model.PublishDate == default ? Model.PublishDate : movie.PublishDate;
            movie.Price = Model.Price == default ? Model.Price : movie.Price;
            movie.GenreId = Model.GenreId == default ? Model.DirectorId : movie.DirectorId;
            movie.DirectorId = Model.DirectorId == default ? Model.DirectorId : movie.DirectorId;
            _context.SaveChanges();
        }
    }
    public class UpdateMovieViewModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}