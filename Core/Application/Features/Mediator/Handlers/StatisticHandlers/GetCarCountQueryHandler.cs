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
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IDashboardRepository _repository;

        public GetCarCountQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }
       
        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCount();
            return new GetCarCountQueryResult
            {
                GetCarCount = value
            };
        }
    }
}

