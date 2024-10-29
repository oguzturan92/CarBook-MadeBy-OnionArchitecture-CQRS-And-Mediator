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
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQuery, GetBrandNameByMaxCarQueryResult>
    {
        private readonly IDashboardRepository _repository;

        public GetBrandNameByMaxCarQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandNameByMaxCarQueryResult> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBrandNameByMaxCar();
            return new GetBrandNameByMaxCarQueryResult
            {
                GetBrandNameByMaxCar = value
            };
        }
    }
}