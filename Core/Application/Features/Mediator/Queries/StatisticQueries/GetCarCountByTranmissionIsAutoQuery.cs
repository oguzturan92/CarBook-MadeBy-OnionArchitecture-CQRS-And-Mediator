using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Results.StatisticResults;
using MediatR;

namespace Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarCountByTranmissionIsAutoQuery : IRequest<GetCarCountByTranmissionIsAutoQueryResult>
    {
        
    }
}