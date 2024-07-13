using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetBannerByIdQueryResult
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