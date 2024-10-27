using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.BlogQueries;
using Application.Features.Mediator.Results.BlogResults;
using Application.Interfaces.BlogInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllBlogsWithAuthors();
            var result = values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
                BlogSubTitle = x.BlogSubTitle,
                BlogDescription = x.BlogDescription,
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