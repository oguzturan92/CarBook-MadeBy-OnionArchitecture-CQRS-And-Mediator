using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Blogs.Mediator.Queries.BlogQueries;
using Application.Blogs.Mediator.Results.BlogResults;
using Application.Interfaces;
using Application.Interfaces.BlogInterfaces;
using Domain.Entities;
using MediatR;

namespace Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IBlogRepository _repository;
        public GetBlogByIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBlogByIdWithAuthor(request.Id);
            var result = new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                BlogTitle = value.BlogTitle,
                BlogSubTitle = value.BlogSubTitle,
                BlogDescription = value.BlogDescription,
                BlogImage = value.BlogImage,
                BlogDate = value.BlogDate,
                AuthorId = value.AuthorId,
                AuthorName = value.Author.AuthorName,
                AuthorDescription = value.Author.AuthorDescription,
                AuthorImage = value.Author.AuthorImage,
                CategoryId = value.CategoryId
            };
            return result;
        }
    }
}