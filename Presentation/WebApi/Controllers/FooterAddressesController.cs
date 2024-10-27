using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.FooterAddressQueries;
using Application.FooterAddresss.Mediator.Commands.FooterAddressCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> FooterAddressCreate(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adres Eklendi");
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressGetById()
        {
            var value = await _mediator.Send(new GetFooterAddressOneQuery());
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> FooterAddressUpdate(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adres Güncellendi");
        }

    }
}