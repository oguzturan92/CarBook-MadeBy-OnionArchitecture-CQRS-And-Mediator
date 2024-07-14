using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Mediator.Queries.ServiceQueries;
using Application.Services.Mediator.Results.ServiceResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;
        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetServiceQueryResult
            {
                ServiceId = x.ServiceId,
                ServiceTitle = x.ServiceTitle,
                ServiceDescription = x.ServiceDescription,
                ServiceIcon = x.ServiceIcon
            }).ToList();
            return result;
        }
    }
}