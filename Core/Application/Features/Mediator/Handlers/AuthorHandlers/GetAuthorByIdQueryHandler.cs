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
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;
        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetAuthorByIdQueryResult
            {
                AuthorId = value.AuthorId,
                AuthorName = value.AuthorName,
                AuthorImage = value.AuthorImage,
                AuthorDescription = value.AuthorDescription
            };
            return result;
        }
    }
}