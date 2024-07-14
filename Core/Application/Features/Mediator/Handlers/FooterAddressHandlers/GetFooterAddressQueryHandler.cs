using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.FooterAddresss.Mediator.Queries.FooterAddressQueries;
using Application.FooterAddresss.Mediator.Results.FooterAddressResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;
        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetFooterAddressQueryResult
            {
                FooterAddressId = x.FooterAddressId,
                FooterAddressDescription = x.FooterAddressDescription,
                FooterAddressContent = x.FooterAddressContent,
                FooterAddressPhone = x.FooterAddressPhone,
                FooterAddressMail = x.FooterAddressMail
            }).ToList();
            return result;
        }
    }
}