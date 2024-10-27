using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TagClouds.Mediator.Commands.TagCloudCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TagClouds.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;
        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudId);
            value.TagCloudTitle = request.TagCloudTitle;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);
        }
    }
}