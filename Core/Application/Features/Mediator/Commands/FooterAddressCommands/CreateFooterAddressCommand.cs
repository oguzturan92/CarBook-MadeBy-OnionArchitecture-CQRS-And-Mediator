using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.FooterAddresss.Mediator.Commands.FooterAddressCommands
{
    public class CreateFooterAddressCommand : IRequest
    {
        public string FooterAddressDescription { get; set; }
        public string FooterAddressContent { get; set; }
        public string FooterAddressPhone { get; set; }
        public string FooterAddressMail { get; set; }
    }
}