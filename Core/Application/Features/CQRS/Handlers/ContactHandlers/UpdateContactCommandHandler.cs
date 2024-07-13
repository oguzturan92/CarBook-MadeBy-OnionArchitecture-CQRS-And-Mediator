using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactId);
            value.ContactName = command.ContactName;
            value.ContactMail = command.ContactMail;
            value.ContactSubject = command.ContactSubject;
            value.ContactMessage = command.ContactMessage;
            value.ContactDate = command.ContactDate;
            await _repository.UpdateAsync(value);
        }
    }
}