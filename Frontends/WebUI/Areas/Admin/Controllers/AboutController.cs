using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> AboutUpdate()
        {
            ViewBag.aboutActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Abouts/");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateAboutDto = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(updateAboutDto);
            }

            return RedirectToAction("AboutUpdate", "About");
        }

        [HttpPost]
        public async Task<IActionResult> AboutUpdate(UpdateAboutDto updateAboutDto)
        {
            ViewBag.aboutActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
             HttpResponseMessage responseMessage = new();
            
            // AboutId 0 ise sayfaya veri gitmemiştir ve ilk öge eklemek için PostAsync çalışır
            if (updateAboutDto.AboutId == 0)
            {
                responseMessage = await client.PostAsync("https://localhost:7105/api/Abouts", stringContent);
            } else
            {
                responseMessage = await client.PutAsync("https://localhost:7105/api/Abouts", stringContent);
            }
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AboutUpdate", "About");
            }

            return RedirectToAction("AboutUpdate", "About");
        }
        
    }
}