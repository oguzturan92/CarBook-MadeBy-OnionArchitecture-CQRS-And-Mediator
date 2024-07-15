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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = new Blog
            {
                BlogTitle = request.BlogTitle,
                BlogImage = request.BlogImage,
                BlogDate = DateTime.Now,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId
            };
            await _repository.CreateAsync(entity);
        }
    }
}