using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Blogs.Mediator.Commands.BlogCommands;
using Application.Blogs.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> BlogCreate(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BlogGetById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> BlogUpdate(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> BlogDelete(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog Silindi");
        }

        [HttpGet("GetBlogLast3WithAuthor")]
        public async Task<IActionResult> GetBlogLast3WithAuthor()
        {
            var values = await _mediator.Send(new GetBlogLast3WithAuthorQuery());
            return Ok(values);
        }

    }
}