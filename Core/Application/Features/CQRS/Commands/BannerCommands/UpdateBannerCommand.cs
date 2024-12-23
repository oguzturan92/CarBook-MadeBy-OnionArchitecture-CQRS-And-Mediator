using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateBannerCommand
    {
        public int BannerId { get; set; }
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerVideoTitle { get; set; }
        public string BannerVideoUrl { get; set; }
    }
}