using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.FooterAddresss.Mediator.Commands.FooterAddressCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;
        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = new FooterAddress
            {
                FooterAddressDescription = request.FooterAddressDescription,
                FooterAddressContent = request.FooterAddressContent,
                FooterAddressPhone = request.FooterAddressPhone,
                FooterAddressMail = request.FooterAddressMail
            };
            await _repository.CreateAsync(entity);
        }
    }
}