using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Testimonials.Mediator.Queries.TestimonialQueries;
using Application.Testimonials.Mediator.Results.TestimonialResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;
        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetTestimonialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                TestimonialFullname = value.TestimonialFullname,
                TestimonialTitle = value.TestimonialTitle,
                TestimonialComment = value.TestimonialComment,
                TestimonialImage = value.TestimonialImage
            };
            return result;
        }
    }
}