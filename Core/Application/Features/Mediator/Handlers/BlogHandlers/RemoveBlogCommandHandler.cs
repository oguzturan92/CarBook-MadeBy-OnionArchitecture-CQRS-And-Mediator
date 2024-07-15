using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Blogs.Mediator.Commands.BlogCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}