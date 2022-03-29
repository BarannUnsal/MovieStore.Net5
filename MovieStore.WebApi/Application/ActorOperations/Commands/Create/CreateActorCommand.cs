using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.ActorOperations.Commands.Create
{
    public class CreateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorViewModel Model { get; set; }
        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (actor != null)
            {
                throw new InvalidOperationException("Girmiş olduğunuz oyuncu bilgileri mevcut!");
            }
            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }
    public class CreateActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}