using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommand
    {
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string CarBıgImage { get; set; }
        public string CarImage { get; set; }
        public int CarKm { get; set; }
        public string CarTransmission { get; set; }
        public byte CarSeat { get; set; }
        public byte CarLuggage { get; set; }
        public string CarFuelType { get; set; }
        public int BrandId { get; set; }
    }
}