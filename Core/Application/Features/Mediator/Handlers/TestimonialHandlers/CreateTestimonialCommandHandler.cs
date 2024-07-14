using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Testimonials.Mediator.Commands.TestimonialCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = new Testimonial
            {
                TestimonialFullname = request.TestimonialFullname,
                TestimonialTitle = request.TestimonialTitle,
                TestimonialComment = request.TestimonialComment,
                TestimonialImage = request.TestimonialImage
            };
            await _repository.CreateAsync(entity);
        }
    }
}