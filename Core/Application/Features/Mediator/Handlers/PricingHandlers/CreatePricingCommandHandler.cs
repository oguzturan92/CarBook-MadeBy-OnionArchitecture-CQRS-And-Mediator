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
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Pricing
            {
                PricingName = request.PricingName
            };
            await _repository.CreateAsync(entity);
        }
    }
}