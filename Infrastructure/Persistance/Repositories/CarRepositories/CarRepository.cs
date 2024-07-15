using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.CarRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;
        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarWithBrand()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<Car>> GetCarWithBrandLast5()
        {
            return await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(5).ToListAsync();
        }
    }
}