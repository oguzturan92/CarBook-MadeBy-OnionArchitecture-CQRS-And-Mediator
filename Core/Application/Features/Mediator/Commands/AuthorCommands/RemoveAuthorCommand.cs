using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Authors.Mediator.Commands.AuthorCommands
{
    public class RemoveAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveAuthorCommand(int id)
        {
            Id = id;
        }
    }
}