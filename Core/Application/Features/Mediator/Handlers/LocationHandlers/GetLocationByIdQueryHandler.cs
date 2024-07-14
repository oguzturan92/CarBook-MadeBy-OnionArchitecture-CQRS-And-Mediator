using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Locations.Mediator.Queries.LocationQueries;
using Application.Locations.Mediator.Results.LocationResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;
        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetLocationByIdQueryResult
            {
                LocationId = value.LocationId,
                LocationName = value.LocationName
            };
            return result;
        }
    }
}