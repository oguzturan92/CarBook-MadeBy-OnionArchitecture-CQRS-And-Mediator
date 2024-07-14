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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;
        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetServiceByIdQueryResult
            {
                ServiceId = value.ServiceId,
                ServiceTitle = value.ServiceTitle,
                ServiceDescription = value.ServiceDescription,
                ServiceIcon = value.ServiceIcon
            };
            return result;
        }
    }
}