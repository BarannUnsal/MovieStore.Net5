using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.DirectorOperations.Commands.Update
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateDirectorViewModel Model { get; set; }
        public int DirectorId { get; set; }
        public UpdateDirectorCommand(IMovieStoreDbContext context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var director = _context.Directors.Find(DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz yönetmen bulunamadı!");
            }
            director.Name = Model.Name == default ? Model.Name : director.Name;
            director.Surname = Model.Surname == default ? Model.Surname : director.Surname;
            director.isActive = Model.isActive == default ? Model.isActive : director.isActive;
            _context.SaveChanges();
        }
    }
    public class UpdateDirectorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isActive { get; set; }
    }
}