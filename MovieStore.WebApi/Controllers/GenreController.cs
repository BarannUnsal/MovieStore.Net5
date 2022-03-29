using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Application.GenreOperations.Command.Create;
using MovieStore.WebApi.Application.GenreOperations.Command.Delete;
using MovieStore.WebApi.Application.GenreOperations.Command.Update;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenres;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenre()
        {
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreDetails(int id)
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(_context, _mapper);
            query.GenreId = id;

            GetGenreDetailsValidator validator = new GetGenreDetailsValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreViewModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = newGenre;

            CreateGenreValidator validator = new CreateGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreViewModel updatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            command.GenreId = id;
            command.Model = updatedGenre;

            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}