using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.PricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> PricingList()
        {
            ViewBag.pricingActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Pricings");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultPricingDtos = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);
                return View(resultPricingDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult PricingCreate()
        {
            ViewBag.pricingActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PricingCreate(CreatePricingDto createPricingDto)
        {
            ViewBag.pricingActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Pricings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("PricingList", "Pricing");
            }

            return RedirectToAction("PricingList", "Pricing");
        }

        [HttpGet]
        public async Task<IActionResult> PricingUpdate(int id)
        {
            ViewBag.pricingActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Pricings/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updatePricingDto = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData);
                return View(updatePricingDto);
            }

            return RedirectToAction("PricingList", "Pricing");
        }

        [HttpPost]
        public async Task<IActionResult> PricingUpdate(UpdatePricingDto updatePricingDto)
        {
            ViewBag.pricingActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updatePricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Pricings", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("PricingList", "Pricing");
            }

            return RedirectToAction("PricingList", "Pricing");
        }

        public async Task<IActionResult> PricingDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Pricings/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("PricingList", "Pricing");
            }

            return RedirectToAction("PricingList", "Pricing");
        }
    }
}