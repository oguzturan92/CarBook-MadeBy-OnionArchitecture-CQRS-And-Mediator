using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Testimonials.Mediator.Results.TestimonialResults;
using MediatR;

namespace Application.Testimonials.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
    {
        
    }
}