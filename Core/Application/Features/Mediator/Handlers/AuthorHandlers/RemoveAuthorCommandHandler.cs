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
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}