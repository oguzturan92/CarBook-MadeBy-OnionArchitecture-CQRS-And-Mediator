using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public int Id { get; set; }
        public RemoveContactCommand(int id)
        {
            Id = id;
        }
    }
}