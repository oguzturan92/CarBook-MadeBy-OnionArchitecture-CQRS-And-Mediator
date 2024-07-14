using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Locations.Mediator.Commands.LocationCommands
{
    public class CreateLocationCommand : IRequest
    {
        public string LocationName { get; set; }
    }
}