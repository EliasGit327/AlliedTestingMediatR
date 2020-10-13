using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Registrations.Commands.CreateRegistration;
using Application.Registrations.Queries.GetAllRegistrations;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("registrations")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            var response = await _mediator.Send(new GetRegistrationQuery() { Id = id });
            return response != null ? Ok(response) : NotFound() as ActionResult;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllRegistrationsQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateRegistrationDto>> CreateRegistration([FromBody] CreateRegistrationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}