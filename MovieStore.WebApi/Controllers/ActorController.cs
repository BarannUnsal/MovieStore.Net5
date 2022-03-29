using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Application.ActorOperations.Commands.Create;
using MovieStore.WebApi.Application.ActorOperations.Commands.Delete;
using MovieStore.WebApi.Application.ActorOperations.Commands.Update;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActors;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActor()
        {
            GetActorQuery query = new GetActorQuery(_context);
            var obj = query.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetActorDetails(int id)
        {
            GetActorDetialsQuery query = new GetActorDetialsQuery(_context, _mapper);
            query.ActorId = id;

            GetActorDetialsValidator validator = new GetActorDetialsValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActorViewModel newActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = newActor;

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorViewModel updatedActor)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId = id;
            command.Model = updatedActor;

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}