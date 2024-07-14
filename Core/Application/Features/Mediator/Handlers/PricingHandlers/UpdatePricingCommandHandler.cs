using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pricings.Mediator.Commands.PricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Pricings.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            value.PricingName = request.PricingName;
            await _repository.UpdateAsync(value);
        }
    }
}