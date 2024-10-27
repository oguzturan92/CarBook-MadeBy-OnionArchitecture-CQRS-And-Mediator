using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authors.Mediator.Commands.AuthorCommands;
using Application.Authors.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AuthorCreate(CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Author Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AuthorGetById(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> AuthorUpdate(UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Author Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> AuthorDelete(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Author Silindi");
        }

    }
}