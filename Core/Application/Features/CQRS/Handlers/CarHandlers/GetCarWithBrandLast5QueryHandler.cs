using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Application.Interfaces.CarRepositories;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandLast5QueryHandler
    {
        private readonly ICarRepository _repository;
        public GetCarWithBrandLast5QueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandLast5QueryResult>> Handle()
        {
            var values = await _repository.GetCarWithBrandLast5();
            var result = values.Select(x => new GetCarWithBrandLast5QueryResult
            {
                CarId = x.CarId,
                CarModel = x.CarModel,
                CarBıgImage = x.CarBıgImage,
                CarImage = x.CarImage,
                CarKm = x.CarKm,
                CarTransmission = x.CarTransmission,
                CarSeat = x.CarSeat,
                CarLuggage = x.CarLuggage,
                CarFuelType = x.CarFuelType,
                BrandId = x.BrandId,
                BrandName = x.Brand.BrandName
            }).ToList();
            return result;
        }
    }
}