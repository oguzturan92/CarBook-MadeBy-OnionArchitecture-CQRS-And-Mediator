using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using Application.Interfaces.CarInterfaces;
using Application.Interfaces.DashboardInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IDashboardRepository _repository;

        public GetBlogCountQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBlogCount();
            return new GetBlogCountQueryResult
            {
                GetBlogCount = value
            };
        }
    }
}