using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string CarBıgImage { get; set; }
        public string CarImage { get; set; }
        public int CarKm { get; set; }
        public string CarTransmission { get; set; } // Vites
        public byte CarSeat { get; set; } // Koltuk
        public byte CarLuggage { get; set; } // Bagaj
        public string CarFuelType { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}