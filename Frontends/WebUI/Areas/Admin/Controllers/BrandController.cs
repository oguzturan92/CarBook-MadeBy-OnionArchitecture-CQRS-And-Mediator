using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BrandList()
        {
            ViewBag.brandActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Brands");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultBrandDtos = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(resultBrandDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult BrandCreate()
        {
            ViewBag.brandActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BrandCreate(CreateBrandDto createBrandDto)
        {
            ViewBag.brandActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Brands", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BrandList", "Brand");
            }

            return RedirectToAction("BrandList", "Brand");
        }

        [HttpGet]
        public async Task<IActionResult> BrandUpdate(int id)
        {
            ViewBag.brandActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Brands/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateBrandDto = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(updateBrandDto);
            }

            return RedirectToAction("BrandList", "Brand");
        }

        [HttpPost]
        public async Task<IActionResult> BrandUpdate(UpdateBrandDto updateBrandDto)
        {
            ViewBag.brandActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Brands", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BrandList", "Brand");
            }

            return RedirectToAction("BrandList", "Brand");
        }

        public async Task<IActionResult> BrandDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Brands/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BrandList", "Brand");
            }

            return RedirectToAction("BrandList", "Brand");
        }
    }
}