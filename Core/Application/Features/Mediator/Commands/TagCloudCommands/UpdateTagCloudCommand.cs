using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.TagClouds.Mediator.Commands.TagCloudCommands
{
    public class UpdateTagCloudCommand : IRequest
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public int BlogId { get; set; }
    }
}