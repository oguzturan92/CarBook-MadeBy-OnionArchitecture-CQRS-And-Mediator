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
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;
        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationId);
            value.LocationName = request.LocationName;
            await _repository.UpdateAsync(value);
        }
    }
}