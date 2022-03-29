using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Create;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Delete;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Update;
using MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomerDetails;
using MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomers;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CustomerController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            GetCustomerQuery query = new GetCustomerQuery(_context);
            var obj = query.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetActorDetails(int id)
        {
            GetCustomerDetailsQuery query = new GetCustomerDetailsQuery(_context, _mapper);
            query.CustomerId = id;

            GetCustomerDetailsValidator validator = new GetCustomerDetailsValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerViewModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;

            CreateCustomerValidator validator = new CreateCustomerValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerViewModel updatedActor)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.CustomerId = id;
            command.Model = updatedActor;

            UpdateCustomerValidator validator = new UpdateCustomerValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;

            DeleteCustomerValidator validator = new DeleteCustomerValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}