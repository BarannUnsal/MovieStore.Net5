using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Create;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Delete;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Update;
using MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectorDetails;
using MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectors;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirector()
        {
            GetDirectorQuery query = new GetDirectorQuery(_context);
            var obj = query.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetActorDetails(int id)
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(_context, _mapper);
            query.DirectorId = id;

            GetDirectorDetailsValidator validator = new GetDirectorDetailsValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateDirector([FromBody] CreateDirectorViewModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = newDirector;

            CreateDirectorValidator validator = new CreateDirectorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorViewModel updatedDirector)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.DirectorId = id;
            command.Model = updatedDirector;

            UpdateDirectorValidator validator = new UpdateDirectorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;

            DeleteDirectorValidator validator = new DeleteDirectorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}