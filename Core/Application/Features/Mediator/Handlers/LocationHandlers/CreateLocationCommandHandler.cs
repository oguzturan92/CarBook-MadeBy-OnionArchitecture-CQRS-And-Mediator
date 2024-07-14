using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Locations.Mediator.Commands.LocationCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> _repository;
        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Location
            {
                LocationName = request.LocationName
            };
            await _repository.CreateAsync(entity);
        }
    }
}