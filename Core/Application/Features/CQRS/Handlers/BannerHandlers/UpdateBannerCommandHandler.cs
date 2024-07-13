using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerId);
            value.BannerTitle = command.BannerTitle;
            value.BannerSubTitle = command.BannerSubTitle;
            value.BannerVideoTitle = command.BannerVideoTitle;
            value.BannerVideoUrl = command.BannerVideoUrl;
            await _repository.UpdateAsync(value);
        }
    }
}