using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.CarPricingInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;
        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            return await _context.CarPricings
                                        .Include(x => x.Car)
                                        .ThenInclude(x => x.Brand)
                                        .Include(x => x.Pricing).Where(x => x.PricingId == 2)
                                        .ToListAsync();
        }
        
    }
}