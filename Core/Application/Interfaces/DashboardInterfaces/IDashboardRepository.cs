using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces.DashboardInterfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetCarCount();
        Task<int> GetLocationCount();
        Task<int> GetAuthorCount();
        Task<int> GetBlogCount();
        Task<int> GetBrandCount();
        Task<double> GetAvgRentPriceForDaily();
        Task<double> GetAvgRentPriceForWeekly();
        Task<double> GetAvgRentPriceForMonthly();
        Task<int> GetCarCountByTranmissionIsAuto();
        Task<string> GetBrandNameByMaxCar();
        Task<string> GetBlogTitleByMaxBlogComment();
        Task<int> GetCarCountByKmSmallerThen1000();
        Task<int> GetCarCountByFuelGasolineOrDiesel();
        Task<int> GetCarCountByFuelElectric();
        Task<string> GetCarBrandAndModelByRentPriceDailyMax();
        Task<string> GetCarBrandAndModelByRentPriceDailyMin();
    }
}