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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AuthorId);
            value.AuthorName = request.AuthorName;
            value.AuthorImage = request.AuthorImage;
            value.AuthorDescription = request.AuthorDescription;
            await _repository.UpdateAsync(value);
        }
    }
}