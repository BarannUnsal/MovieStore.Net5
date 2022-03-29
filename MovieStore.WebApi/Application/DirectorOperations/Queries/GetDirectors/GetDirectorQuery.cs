using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorQuery(IMovieStoreDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetDirectorViewModel> Handle()
        {
            var director = _context.Directors.Include(x => x.Movies).ToList().OrderBy(x => x.Id);
            List<GetDirectorViewModel> viewModel = _mapper.Map<List<GetDirectorViewModel>>(director);
            return viewModel;
        }

    }
    public class GetDirectorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Movies { get; set; }
    }
}