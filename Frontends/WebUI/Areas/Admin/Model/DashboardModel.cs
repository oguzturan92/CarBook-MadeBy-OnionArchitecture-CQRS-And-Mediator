using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Model
{
    public class DashboardModel
    {
        public int GetCarCount { get; set; }
        public int GetLocationCount { get; set; }
        public int GetAuthorCount { get; set; }
        public int GetBlogCount { get; set; }
        public int GetBrandCount { get; set; }
        public double GetAvgRentPriceForDaily { get; set; }
        public double GetAvgRentPriceForWeekly { get; set; }
        public double GetAvgRentPriceForMonthly { get; set; }
        public int GetCarCountByTranmissionIsAuto { get; set; }
        public string GetBrandNameByMaxCar { get; set; }
        public string GetBlogTitleByMaxBlogComment { get; set; }
        public int GetCarCountByKmSmallerThen1000 { get; set; }
        public int GetCarCountByFuelGasolineOrDiesel { get; set; }
        public int GetCarCountByFuelElectric { get; set; }
        public string GetCarBrandAndModelByRentPriceDailyMax { get; set; }
        public string GetCarBrandAndModelByRentPriceDailyMin { get; set; }
    }
}