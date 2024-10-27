using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Application.Interfaces.BannerInterfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerOneQueryHandler
    {
        private readonly IBannerRepository _repository;
        public GetBannerOneQueryHandler(IBannerRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerOneQueryResult> Handle()
        {
            var value = await _repository.GetFirstOrDefault();
            var result = new GetBannerOneQueryResult
            {
                BannerId = value.BannerId,
                BannerTitle = value.BannerTitle,
                BannerSubTitle = value.BannerSubTitle,
                BannerVideoTitle = value.BannerVideoTitle,
                BannerVideoUrl = value.BannerVideoUrl
            };
            return result;
        }
    }
}