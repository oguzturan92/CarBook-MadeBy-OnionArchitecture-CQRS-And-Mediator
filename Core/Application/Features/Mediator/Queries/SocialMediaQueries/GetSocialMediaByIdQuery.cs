using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.SocialMedias.Mediator.Results.SocialMediaResults;
using MediatR;

namespace Application.SocialMedias.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }
        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}