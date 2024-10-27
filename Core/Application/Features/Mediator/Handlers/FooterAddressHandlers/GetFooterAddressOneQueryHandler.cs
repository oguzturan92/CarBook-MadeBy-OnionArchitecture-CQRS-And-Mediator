using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.FooterAddressQueries;
using Application.FooterAddresss.Mediator.Results.FooterAddressResults;
using Application.Interfaces;
using Application.Interfaces.FooterAddressInterfaces;
using Domain.Entities;
using MediatR;

namespace Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressOneQueryHandler : IRequestHandler<GetFooterAddressOneQuery, GetFooterAddressOneQueryResult>
    {
        private readonly IFooterAddressRepository _repository;
        public GetFooterAddressOneQueryHandler(IFooterAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressOneQueryResult> Handle(GetFooterAddressOneQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetFirstOrDefault();
            var result = new GetFooterAddressOneQueryResult
            {
                FooterAddressId = value.FooterAddressId,
                FooterAddressDescription = value.FooterAddressDescription,
                FooterAddressContent = value.FooterAddressContent,
                FooterAddressPhone = value.FooterAddressPhone,
                FooterAddressMail = value.FooterAddressMail
            };
            return result;
        }
    }
}