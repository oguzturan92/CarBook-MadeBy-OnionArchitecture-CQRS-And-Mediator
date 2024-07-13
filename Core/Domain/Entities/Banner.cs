using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Banner
    {
        public int BannerId { get; set; }
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerVideoTitle { get; set; }
        public string BannerVideoUrl { get; set; }
    }
}