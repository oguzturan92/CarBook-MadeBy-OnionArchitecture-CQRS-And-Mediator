using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authors.Mediator.Results.AuthorResults;
using MediatR;

namespace Application.Authors.Mediator.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdQueryResult>
    {
        public int Id { get; set; }
        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}