using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            var entity = new Contact
            {
                ContactName = command.ContactName,
                ContactMail = command.ContactMail,
                ContactSubject = command.ContactSubject,
                ContactMessage = command.ContactMessage,
                ContactDate = command.ContactDate
            };
            await _repository.CreateAsync(entity);
        }
    }
}