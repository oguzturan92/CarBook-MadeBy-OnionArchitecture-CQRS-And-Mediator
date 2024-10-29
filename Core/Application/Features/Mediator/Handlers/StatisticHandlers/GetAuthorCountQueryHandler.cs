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
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        private readonly IDashboardRepository _repository;

        public GetAuthorCountQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAuthorCount();
            return new GetAuthorCountQueryResult
            {
                GetAuthorCount = value
            };
        }
    }
}