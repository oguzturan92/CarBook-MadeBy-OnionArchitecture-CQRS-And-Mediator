using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public string BrandName { get; set; }
    }
}