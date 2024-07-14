using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Mediator.Commands.ServiceCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceId);
            value.ServiceTitle = request.ServiceTitle;
            value.ServiceDescription = request.ServiceDescription;
            value.ServiceIcon = request.ServiceIcon;
            await _repository.UpdateAsync(value);
        }
    }
}