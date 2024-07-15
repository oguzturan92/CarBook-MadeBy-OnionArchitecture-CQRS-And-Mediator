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
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;
        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetBlogQueryResult
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
                BlogImage = x.BlogImage,
                BlogDate = x.BlogDate,
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId
            }).ToList();
            return result;
        }
    }
}