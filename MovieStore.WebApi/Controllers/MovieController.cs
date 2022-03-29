using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Application.GenreOperations.Command.Update;
using MovieStore.WebApi.Application.MovieOperations.Command.Create;
using MovieStore.WebApi.Application.MovieOperations.Command.Delete;
using MovieStore.WebApi.Application.MovieOperations.Command.Update;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetails;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovies;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovie()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieDetails(int id)
        {
            GetMovieDetailsQuery query = new GetMovieDetailsQuery(_context, _mapper);
            query.MovieId = id;

            GetMovieDetailsValidator validator = new GetMovieDetailsValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieViewModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = newMovie;

            CreateMovieValidator validator = new CreateMovieValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieViewModel updatedMovie)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.MovieId = id;
            command.Model = updatedMovie;

            UpdateMovieValidator validator = new UpdateMovieValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;

            DeleteMovieValidator validator = new DeleteMovieValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}