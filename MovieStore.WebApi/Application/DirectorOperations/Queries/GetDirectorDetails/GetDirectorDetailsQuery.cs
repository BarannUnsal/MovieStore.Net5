using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorDetailsViewModel Model { get; set; }
        public int DirectorId { get; set; }
        public GetDirectorDetailsQuery(IMovieStoreDbContext context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetDirectorDetailsViewModel Handle()
        {
            var director = _context.Directors.Include(x => x.Movies).SingleOrDefault(x => x.Id == DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Aradığınız yönetmen bulunamadı!");
            }
            var viewModel = _mapper.Map<GetDirectorDetailsViewModel>(director);
            return viewModel;
        }
    }
    public class GetDirectorDetailsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isActive { get; set; }
        public List<string> Movies { get; set; }
    }
}