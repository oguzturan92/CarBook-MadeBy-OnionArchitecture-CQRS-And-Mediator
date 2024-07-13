using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarId);
            value.CarModel = command.CarModel;
            value.CarBıgImage = command.CarBıgImage;
            value.CarImage = command.CarImage;
            value.CarKm = command.CarKm;
            value.CarTransmission = command.CarTransmission;
            value.CarSeat = command.CarSeat;
            value.CarLuggage = command.CarLuggage;
            value.CarFuelType = command.CarFuelType;
            value.BrandId = command.BrandId;
            await _repository.UpdateAsync(value);
        }
    }
}