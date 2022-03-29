using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.DirectorOperations.Commands.Create
{
    public class CreateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorViewModel Model { get; set; }
        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (director != null)
            {
                throw new InvalidOperationException("Girmiş olduğunuz bilgilere sahip bir yönetmen mevcut. Lütfen yeni bir yönetmen giriniz.");
            }
            director = _mapper.Map<Director>(Model);
            _context.Directors.Add(director);
            _context.SaveChanges();
        }
    }
    public class CreateDirectorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}