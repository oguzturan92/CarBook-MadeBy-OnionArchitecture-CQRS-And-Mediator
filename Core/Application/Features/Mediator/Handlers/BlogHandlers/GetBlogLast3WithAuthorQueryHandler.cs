using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Blogs.Mediator.Queries.BlogQueries;
using Application.Blogs.Mediator.Results.BlogResults;
using Application.Interfaces;
using Application.Interfaces.BlogRepository;
using Domain.Entities;
using MediatR;

namespace Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogLast3WithAuthorQueryHandler : IRequestHandler<GetBlogLast3WithAuthorQuery, List<GetBlogLast3WithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogLast3WithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogLast3WithAuthorQueryResult>> Handle(GetBlogLast3WithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogLast3WithAuthor();
            var result = values.Select(x => new GetBlogLast3WithAuthorQueryResult
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
                BlogImage = x.BlogImage,
                BlogDate = x.BlogDate,
                AuthorId = x.AuthorId,
                AuthorName = x.Author.AuthorName,
                CategoryId = x.CategoryId
            }).ToList();
            return result;
        }
    }
}