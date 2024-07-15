using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authors.Mediator.Queries.AuthorQueries;
using Application.Authors.Mediator.Results.AuthorResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Authors.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;
        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                AuthorImage = x.AuthorImage,
                AuthorDescription = x.AuthorDescription
            }).ToList();
            return result;
        }
    }
}