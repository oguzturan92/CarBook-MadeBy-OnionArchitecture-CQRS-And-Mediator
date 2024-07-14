using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            var entity = new About
            {
                AboutTitle = command.AboutTitle,
                AboutDescription = command.AboutDescription,
                AboutImage = command.AboutImage
            };
            await _repository.CreateAsync(entity);
        }
    }
}