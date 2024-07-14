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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;
        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaId);
            value.SocialMediaIcon = request.SocialMediaIcon;
            value.SocialMediaUrl = request.SocialMediaUrl;
            await _repository.UpdateAsync(value);
        }
    }
}