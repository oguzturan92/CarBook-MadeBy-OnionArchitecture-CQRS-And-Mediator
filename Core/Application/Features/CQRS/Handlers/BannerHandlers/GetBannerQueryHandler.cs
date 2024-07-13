using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                BannerTitle = x.BannerTitle,
                BannerSubTitle = x.BannerSubTitle,
                BannerVideoTitle = x.BannerVideoTitle,
                BannerVideoUrl = x.BannerVideoUrl
            }).ToList();
            return result;
        }
    }
}