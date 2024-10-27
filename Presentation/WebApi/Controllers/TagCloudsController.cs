using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TagClouds.Mediator.Commands.TagCloudCommands;
using Application.TagClouds.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> TagCloudCreate(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TagCloudGetById(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> TagCloudUpdate(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> TagCloudDelete(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket Silindi");
        }

        [HttpGet("GetTagCloudByBlogId/{id}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(value);
        }

    }
}