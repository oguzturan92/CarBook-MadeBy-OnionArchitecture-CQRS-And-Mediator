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
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;
        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var entity = new TagCloud
            {
                TagCloudTitle = request.TagCloudTitle,
                BlogId = request.BlogId
            };
            await _repository.CreateAsync(entity);
        }
    }
}