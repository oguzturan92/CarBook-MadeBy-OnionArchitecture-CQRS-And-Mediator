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
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;
        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialId = x.TestimonialId,
                TestimonialFullname = x.TestimonialFullname,
                TestimonialTitle = x.TestimonialTitle,
                TestimonialComment = x.TestimonialComment,
                TestimonialImage = x.TestimonialImage
            }).ToList();
            return result;
        }
    }
}