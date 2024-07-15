using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Blogs.Mediator.Queries.BlogQueries;
using Application.Blogs.Mediator.Results.BlogResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;
        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                BlogTitle = value.BlogTitle,
                BlogImage = value.BlogImage,
                BlogDate = value.BlogDate,
                AuthorId = value.AuthorId,
                CategoryId = value.CategoryId
            };
            return result;
        }
    }
}