using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.SocialMedias.Mediator.Results.SocialMediaResults
{
    public class GetSocialMediaQueryResult
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaIcon{ get; set; }
        public string SocialMediaUrl { get; set; }
    }
}