using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.FooterAddresss.Mediator.Commands.FooterAddressCommands;
using Application.FooterAddresss.Mediator.Queries.FooterAddressQueries;
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

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> FooterAddressCreate(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAddress Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FooterAddressGetById(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> FooterAddressUpdate(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAddress Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> FooterAddressDelete(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("FooterAddress Silindi");
        }

    }
}