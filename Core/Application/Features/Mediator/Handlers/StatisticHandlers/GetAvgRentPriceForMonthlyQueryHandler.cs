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
    public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
    {
        private readonly IDashboardRepository _repository;

        public GetAvgRentPriceForMonthlyQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAvgRentPriceForMonthly();
            return new GetAvgRentPriceForMonthlyQueryResult
            {
                GetAvgRentPriceForMonthly = value
            };
        }
    }
}