using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.DashboardInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.DashboardRepository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly CarBookContext _context;

        public DashboardRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> GetAuthorCount()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<double> GetAvgRentPriceForDaily()
        {
            decimal averageAmount = await _context.CarPricings.Where(cp => cp.Pricing.PricingName == "Günlük").AverageAsync(cp => cp.Amount);
            return Convert.ToDouble(averageAmount);
        }

        public async Task<double> GetAvgRentPriceForMonthly()
        {
            decimal averageAmount = await _context.CarPricings.Where(cp => cp.Pricing.PricingName == "Aylık").AverageAsync(cp => cp.Amount);
            return Convert.ToDouble(averageAmount);
        }

        public async Task<double> GetAvgRentPriceForWeekly()
        {
            decimal averageAmount = await _context.CarPricings.Where(cp => cp.Pricing.PricingName == "Haftalık").AverageAsync(cp => cp.Amount);
            return Convert.ToDouble(averageAmount);
        }

        public async Task<int> GetBlogCount()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<string> GetBlogTitleByMaxBlogComment()
        {
            var blog = _context.Blogs.Include(i => i.Comments).OrderByDescending(i => i.Comments.Count()).FirstOrDefault();
            return await Task.FromResult(blog.BlogTitle.Length > 30 ? blog.BlogTitle.Substring(0, 30)+"..." : blog.BlogTitle);
        }

        public async Task<int> GetBrandCount()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<string> GetBrandNameByMaxCar()
        {
            var brand = _context.Brands.Include(i => i.Cars).OrderByDescending(i => i.Cars.Count()).FirstOrDefault();
            return await Task.FromResult(brand.BrandName.Length > 30 ? brand.BrandName.Substring(0, 30)+"..." : brand.BrandName);
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var maxPriceDailyCar = _context.Cars.Include(i => i.CarPricings).Where(i => i.CarPricings.Any(i => i.PricingId == 2)).OrderByDescending(i => i.CarPricings.Max(i => i.Amount)).FirstOrDefault();
            return await Task.FromResult(maxPriceDailyCar.CarModel);
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var minPriceDailyCar = _context.Cars.Include(i => i.CarPricings).Where(i => i.CarPricings.Any(i => i.PricingId == 2)).OrderBy(i => i.CarPricings.Min(i => i.Amount)).FirstOrDefault();
            return await Task.FromResult(minPriceDailyCar.CarModel);
        }

        public async Task<int> GetCarCount()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetCarCountByFuelElectric()
        {
            return await _context.Cars.Where(i => i.CarFuelType == "Elektrik").CountAsync();
        }

        public async Task<int> GetCarCountByFuelGasolineOrDiesel()
        {
            return await _context.Cars.Where(i => i.CarFuelType == "Benzin" || i.CarFuelType == "Dizel").CountAsync();
        }

        public async Task<int> GetCarCountByKmSmallerThen1000()
        {
            return await _context.Cars.Where(i => i.CarKm <= 1000).CountAsync();
        }

        public async Task<int> GetCarCountByTranmissionIsAuto()
        {
            var count = _context.Cars.Where(i => i.CarTransmission == "Otomatik").Count();
            return await Task.FromResult(count);
        }

        public async Task<int> GetLocationCount()
        {
            return await _context.Locations.CountAsync();
        }
    }
}