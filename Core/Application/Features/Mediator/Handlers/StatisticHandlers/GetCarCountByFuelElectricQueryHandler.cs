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
    public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
    {
        private readonly IDashboardRepository _repository;

        public GetCarCountByFuelElectricQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCountByFuelElectric();
            return new GetCarCountByFuelElectricQueryResult
            {
                GetCarCountByFuelElectric = value
            };
        }
    }
}