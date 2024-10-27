using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.SocialMedias.Mediator.Commands.SocialMediaCommands;
using Application.SocialMedias.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SocialMediaCreate(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("SocialMedia Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SocialMediaGetById(int id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> SocialMediaUpdate(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("SocialMedia Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SocialMediaDelete(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("SocialMedia Silindi");
        }

    }
}