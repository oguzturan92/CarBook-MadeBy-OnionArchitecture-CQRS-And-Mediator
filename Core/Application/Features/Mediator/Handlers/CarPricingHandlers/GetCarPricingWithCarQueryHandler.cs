using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithCars();
            var results = values.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarPricingId = x.CarPricingId,
                Brand = x.Car.Brand.BrandName,
                Model = x.Car.CarModel,
                CoverImageUrl = x.Car.CarBıgImage,
                Amount = x.Amount
            }).ToList();
            return results;
        }
    }
}