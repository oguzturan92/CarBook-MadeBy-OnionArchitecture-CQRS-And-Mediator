using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> BannerUpdate()
        {
            ViewBag.bannerActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Banners/");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateBannerDto = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);
                return View(updateBannerDto);
            }

            return RedirectToAction("BannerUpdate", "Banner");
        }

        [HttpPost]
        public async Task<IActionResult> BannerUpdate(UpdateBannerDto updateBannerDto)
        {
            ViewBag.bannerActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
             HttpResponseMessage responseMessage = new();
            
            // BannerId 0 ise sayfaya veri gitmemiştir ve ilk öge eklemek için PostAsync çalışır
            if (updateBannerDto.BannerId == 0)
            {
                responseMessage = await client.PostAsync("https://localhost:7105/api/Banners", stringContent);
            } else
            {
                responseMessage = await client.PutAsync("https://localhost:7105/api/Banners", stringContent);
            }
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BannerUpdate", "Banner");
            }

            return RedirectToAction("BannerUpdate", "Banner");
        }
        
    }
}