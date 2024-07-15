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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.BlogTitle = request.BlogTitle;
            value.BlogImage = request.BlogImage;
            value.BlogDate = request.BlogDate;
            value.AuthorId = request.AuthorId;
            value.CategoryId = request.CategoryId;
            await _repository.UpdateAsync(value);
        }
    }
}