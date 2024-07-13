using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                CarModel = command.CarModel,
                CarBıgImage = command.CarBıgImage,
                CarImage = command.CarImage,
                CarKm = command.CarKm,
                CarTransmission = command.CarTransmission,
                CarSeat = command.CarSeat,
                CarLuggage = command.CarLuggage,
                CarFuelType = command.CarFuelType,
                BrandId = command.BrandId
            });
        }
    }
}