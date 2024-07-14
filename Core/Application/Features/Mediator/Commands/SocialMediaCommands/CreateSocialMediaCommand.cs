using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.SocialMedias.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string SocialMediaIcon{ get; set; }
        public string SocialMediaUrl { get; set; }
    }
}