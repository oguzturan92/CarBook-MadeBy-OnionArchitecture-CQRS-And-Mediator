using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly GetAboutOneQueryHandler _getAboutOneQueryHandler;
        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, GetAboutOneQueryHandler getAboutOneQueryHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _getAboutOneQueryHandler = getAboutOneQueryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AboutCreate(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("About Eklendi");
        }

        [HttpGet]
        public async Task<IActionResult> AboutGet()
        {
            var value = await _getAboutOneQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> AboutUpdate(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("About Güncellendi");
        }

    }
}