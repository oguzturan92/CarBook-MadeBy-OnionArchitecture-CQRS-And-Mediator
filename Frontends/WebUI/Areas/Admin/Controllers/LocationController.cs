using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> LocationList()
        {
            ViewBag.locationActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultLocationDtos = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(resultLocationDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult LocationCreate()
        {
            ViewBag.locationActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LocationCreate(CreateLocationDto createLocationDto)
        {
            ViewBag.locationActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Locations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("LocationList", "Location");
            }

            return RedirectToAction("LocationList", "Location");
        }

        [HttpGet]
        public async Task<IActionResult> LocationUpdate(int id)
        {
            ViewBag.locationActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Locations/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateLocationDto = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(updateLocationDto);
            }

            return RedirectToAction("LocationList", "Location");
        }

        [HttpPost]
        public async Task<IActionResult> LocationUpdate(UpdateLocationDto updateLocationDto)
        {
            ViewBag.locationActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Locations", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("LocationList", "Location");
            }

            return RedirectToAction("LocationList", "Location");
        }

        public async Task<IActionResult> LocationDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Locations/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("LocationList", "Location");
            }

            return RedirectToAction("LocationList", "Location");
        }
    }
}