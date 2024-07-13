using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetCarQueryResult
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
                BrandId = x.BrandId
            }).ToList();
            return result;
        }
    }
}