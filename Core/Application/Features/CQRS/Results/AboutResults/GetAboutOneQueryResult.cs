using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Results.AboutResults
{
    public class GetAboutOneQueryResult
    {
        public int AboutId { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutImage { get; set; }
    }
}