using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Testimonials.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveTestimonialCommand(int id)
        {
            Id = id;
        }
    }
}