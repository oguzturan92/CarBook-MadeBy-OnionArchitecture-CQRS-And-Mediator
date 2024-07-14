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
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;
        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetFooterAddressByIdQueryResult
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