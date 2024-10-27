using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pricings.Mediator.Commands.PricingCommands;
using Application.Pricings.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> PricingCreate(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing Eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PricingGetById(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> PricingUpdate(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> PricingDelete(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Pricing Silindi");
        }

    }
}