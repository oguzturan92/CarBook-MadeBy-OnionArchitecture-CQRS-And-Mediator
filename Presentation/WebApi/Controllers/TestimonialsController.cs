using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Testimonials.Mediator.Commands.TestimonialCommands;
using Application.Testimonials.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialCreate(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Testimonial Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TestimonialGetById(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> TestimonialUpdate(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Testimonial Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> TestimonialDelete(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Testimonial Silindi");
        }

    }
}