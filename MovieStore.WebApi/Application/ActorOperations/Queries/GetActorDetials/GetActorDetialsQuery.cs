using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials
{
    public class GetActorDetialsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorDetailsViewModel Model { get; set; }
        public int ActorId { get; set; }
        public GetActorDetialsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetActorDetailsViewModel Handle()
        {
            var actor = _context.Actors.Include(x => x.MovieActors).ThenInclude(x => x.Movie).SingleOrDefault(x => x.Id == ActorId);
            if (actor == null)
            {
                throw new InvalidOperationException("Aradığınız aktör bulunamadı!");
            }
            GetActorDetailsViewModel viewModel = _mapper.Map<GetActorDetailsViewModel>(actor);
            return viewModel;
        }
    }
    public class GetActorDetailsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isActive { get; set; }
        public List<string> Movies { get; set; }
    }
}