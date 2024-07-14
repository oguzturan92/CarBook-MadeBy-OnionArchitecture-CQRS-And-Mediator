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
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Service
            {
                ServiceTitle = request.ServiceTitle,
                ServiceDescription = request.ServiceDescription,
                ServiceIcon = request.ServiceIcon
            };
            await _repository.CreateAsync(entity);
        }
    }
}