using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Locations.Mediator.Commands.LocationCommands;
using Application.Locations.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> LocationCreate(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> LocationGetById(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> LocationUpdate(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> LocationDelete(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location Silindi");
        }

    }
}