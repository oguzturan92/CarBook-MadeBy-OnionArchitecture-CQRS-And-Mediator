using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.SocialMedias.Mediator.Commands.SocialMediaCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.SocialMedias.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;
        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}