using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.BrandDtos;
using Frontends.Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CarList()
        {
            ViewBag.carActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Cars/GetCarWithBrand");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultCarWithBrandDtos = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(resultCarWithBrandDtos);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CarCreate()
        {
            ViewBag.carActive = "active";

            var client = _httpClientFactory.CreateClient();

            CreateCarDto createCarDto = new();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                createCarDto.ResultBrandDtos = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(createCarDto);
            }

            return RedirectToAction("CarList", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> CarCreate(CreateCarDto createCarDto)
        {
            ViewBag.carActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Cars", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("CarList", "Car");
            }

            return RedirectToAction("CarList", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> CarUpdate(int id)
        {
            ViewBag.carActive = "active";

            var client = _httpClientFactory.CreateClient();

            UpdateCarDto updateCarDto = new();

            // Get Car
            var responseMessage = await client.GetAsync("https://localhost:7105/api/Cars/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                updateCarDto = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
            } else
            {
                return RedirectToAction("CarList", "Car");
            }
            
            // Get Brands
            var responseMessage2 = await client.GetAsync("https://localhost:7105/api/Brands");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                updateCarDto.ResultBrandDtos = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(updateCarDto);
            }

            return RedirectToAction("CarList", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> CarUpdate(UpdateCarDto updateCarDto)
        {
            ViewBag.carActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Cars", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("CarList", "Car");
            }

            return RedirectToAction("CarList", "Car");
        }

        public async Task<IActionResult> CarDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Cars/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("CarList", "Car");
            }

            return RedirectToAction("CarList", "Car");
        }
    }
}