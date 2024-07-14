using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Pricings.Mediator.Commands.PricingCommands
{
    public class CreatePricingCommand : IRequest
    {
        public string PricingName { get; set; }
    }
}