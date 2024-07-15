using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Authors.Mediator.Commands.AuthorCommands
{
    public class CreateAuthorCommand : IRequest
    {
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDescription { get; set; }
    }
}