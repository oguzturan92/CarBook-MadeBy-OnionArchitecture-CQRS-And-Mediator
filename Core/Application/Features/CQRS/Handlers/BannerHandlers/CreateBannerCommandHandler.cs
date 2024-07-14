using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand command)
        {
            var entity = new Banner
            {
                BannerTitle = command.BannerTitle,
                BannerSubTitle = command.BannerSubTitle,
                BannerVideoTitle = command.BannerVideoTitle,
                BannerVideoUrl = command.BannerVideoUrl
            };
            await _repository.CreateAsync(entity);
        }
    }
}