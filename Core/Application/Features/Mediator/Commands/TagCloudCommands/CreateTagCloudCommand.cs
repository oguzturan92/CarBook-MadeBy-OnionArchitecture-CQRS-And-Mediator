using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.TagClouds.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudCommand : IRequest
    {
        public string TagCloudTitle { get; set; }
        public int BlogId { get; set; }
    }
}