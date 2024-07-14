using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Mediator.Results.ServiceResults;
using MediatR;

namespace Application.Services.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
    {
        public int Id { get; set; }
        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}