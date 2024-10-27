using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly GetBannerOneQueryHandler _getBannerOneQueryHandler;
        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, GetBannerOneQueryHandler getBannerOneQueryHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _getBannerOneQueryHandler = getBannerOneQueryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> BannerCreate(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner Eklendi");
        }

        [HttpGet]
        public async Task<IActionResult> BannerGet()
        {
            var value = await _getBannerOneQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> BannerUpdate(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner Güncellendi");
        }

    }
}