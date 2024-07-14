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
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;
        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}