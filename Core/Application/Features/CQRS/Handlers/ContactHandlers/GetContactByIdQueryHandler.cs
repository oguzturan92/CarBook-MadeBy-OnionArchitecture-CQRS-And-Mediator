using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                ContactName = value.ContactName,
                ContactMail = value.ContactMail,
                ContactSubject = value.ContactSubject,
                ContactMessage = value.ContactMessage,
                ContactDate = value.ContactDate
            };
            return result;
        }
    }
}