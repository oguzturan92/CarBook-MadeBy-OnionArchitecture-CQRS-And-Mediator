using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> FeatureCreate(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FeatureGetById(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> FeatureUpdate(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> FeatureDelete(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Feature Silindi");
        }

    }
}