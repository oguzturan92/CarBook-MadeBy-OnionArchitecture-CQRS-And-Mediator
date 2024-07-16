using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CarPricingWithCarListList")]
        public async Task<IActionResult> CarPricingWithCarListList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }

    }
}