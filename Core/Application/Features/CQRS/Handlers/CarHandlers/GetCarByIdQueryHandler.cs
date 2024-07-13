using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                CarModel = value.CarModel,
                CarBıgImage = value.CarBıgImage,
                CarImage = value.CarImage,
                CarKm = value.CarKm,
                CarTransmission = value.CarTransmission,
                CarSeat = value.CarSeat,
                CarLuggage = value.CarLuggage,
                CarFuelType = value.CarFuelType,
                BrandId = value.BrandId
            };
            return result;
        }
    }
}