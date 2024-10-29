using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Areas.Admin.Model;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.dashboardActive = "active";

            var client = _httpClientFactory.CreateClient();

            DashboardModel dashboardModel = new();
            dashboardModel.GetCarCount = new();

            var responseMessage1 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetCarCount = doc.RootElement.GetProperty("getCarCount").GetInt32();
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetLocationCount = doc.RootElement.GetProperty("getLocationCount").GetInt32();
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetAuthorCount = doc.RootElement.GetProperty("getAuthorCount").GetInt32();
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetBlogCount = doc.RootElement.GetProperty("getBlogCount").GetInt32();
            }

            var responseMessage5 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetBrandCount = doc.RootElement.GetProperty("getBrandCount").GetInt32();
            }

            var responseMessage6 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetAvgRentPriceForDaily = doc.RootElement.GetProperty("getAvgRentPriceForDaily").GetInt32();
            }

            var responseMessage7 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage7.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetAvgRentPriceForWeekly = doc.RootElement.GetProperty("getAvgRentPriceForWeekly").GetInt32();
            }

            var responseMessage8 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage8.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetAvgRentPriceForMonthly = doc.RootElement.GetProperty("getAvgRentPriceForMonthly").GetInt32();
            }

            var responseMessage9 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetCarCountByTranmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage9.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetCarCountByTranmissionIsAuto = doc.RootElement.GetProperty("getCarCountByTranmissionIsAuto").GetInt32();
            }

            var responseMessage10 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage10.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetBrandNameByMaxCar = doc.RootElement.GetProperty("getBrandNameByMaxCar").GetString();
            }

            var responseMessage11 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetBlogTitleByMaxBlogComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage11.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetBlogTitleByMaxBlogComment = doc.RootElement.GetProperty("getBlogTitleByMaxBlogComment").GetString();
            }

            var responseMessage12 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage12.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetCarCountByKmSmallerThen1000 = doc.RootElement.GetProperty("getCarCountByKmSmallerThen1000").GetInt32();
            }

            var responseMessage13 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage13.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetCarCountByFuelGasolineOrDiesel = doc.RootElement.GetProperty("getCarCountByFuelGasolineOrDiesel").GetInt32();
            }

            var responseMessage14 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage14.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetCarCountByFuelElectric = doc.RootElement.GetProperty("getCarCountByFuelElectric").GetInt32();
            }

            var responseMessage15 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage15.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetCarBrandAndModelByRentPriceDailyMax = doc.RootElement.GetProperty("getCarBrandAndModelByRentPriceDailyMax").GetString();
            }

            var responseMessage16 = await client.GetAsync("https://localhost:7105/api/Dashboard/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage16.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                dashboardModel.GetCarBrandAndModelByRentPriceDailyMin = doc.RootElement.GetProperty("getCarBrandAndModelByRentPriceDailyMin").GetString();
            }

            Console.WriteLine(dashboardModel.GetCarCount);
            Console.WriteLine(dashboardModel.GetLocationCount);
            Console.WriteLine(dashboardModel.GetAuthorCount);
            Console.WriteLine(dashboardModel.GetBlogCount);
            Console.WriteLine(dashboardModel.GetBrandCount);
            Console.WriteLine(dashboardModel.GetAvgRentPriceForDaily);
            Console.WriteLine(dashboardModel.GetAvgRentPriceForWeekly);
            Console.WriteLine(dashboardModel.GetAvgRentPriceForMonthly);
            Console.WriteLine(dashboardModel.GetCarCountByTranmissionIsAuto);
            Console.WriteLine(dashboardModel.GetBrandNameByMaxCar);
            Console.WriteLine(dashboardModel.GetBlogTitleByMaxBlogComment);
            Console.WriteLine(dashboardModel.GetCarCountByKmSmallerThen1000);
            Console.WriteLine(dashboardModel.GetCarCountByFuelGasolineOrDiesel);
            Console.WriteLine(dashboardModel.GetCarCountByFuelElectric);
            Console.WriteLine(dashboardModel.GetCarBrandAndModelByRentPriceDailyMax);
            Console.WriteLine(dashboardModel.GetCarBrandAndModelByRentPriceDailyMin);

            return View(dashboardModel);
        }
    }
}