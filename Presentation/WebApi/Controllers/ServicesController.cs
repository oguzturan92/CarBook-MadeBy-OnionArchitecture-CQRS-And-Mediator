using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Mediator.Commands.ServiceCommands;
using Application.Services.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCreate(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ServiceGetById(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> ServiceUpdate(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ServiceDelete(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Service Silindi");
        }

    }
}