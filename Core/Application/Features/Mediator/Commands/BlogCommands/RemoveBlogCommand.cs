using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Blogs.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveBlogCommand(int id)
        {
            Id = id;
        }
    }
}