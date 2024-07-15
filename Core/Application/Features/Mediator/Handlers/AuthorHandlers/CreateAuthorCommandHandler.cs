using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authors.Mediator.Commands.AuthorCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Authors.Mediator.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Author
            {
                AuthorName = request.AuthorName,
                AuthorImage = request.AuthorImage,
                AuthorDescription = request.AuthorDescription
            };
            await _repository.CreateAsync(entity);
        }
    }
}