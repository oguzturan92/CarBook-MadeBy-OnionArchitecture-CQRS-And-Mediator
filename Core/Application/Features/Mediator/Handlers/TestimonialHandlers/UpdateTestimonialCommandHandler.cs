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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            value.TestimonialFullname = request.TestimonialFullname;
            value.TestimonialTitle = request.TestimonialTitle;
            value.TestimonialComment = request.TestimonialComment;
            value.TestimonialImage = request.TestimonialImage;
            await _repository.UpdateAsync(value);
        }
    }
}