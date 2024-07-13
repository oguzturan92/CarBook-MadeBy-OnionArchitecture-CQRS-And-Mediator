using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Results.ContactResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                ContactName = x.ContactName,
                ContactMail = x.ContactMail,
                ContactSubject = x.ContactSubject,
                ContactMessage = x.ContactMessage,
                ContactDate = x.ContactDate
            }).ToList();
            return result;
        }
    }
}