using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SocialMediaList()
        {
            ViewBag.socialMediaActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/SocialMedias");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultSocialMediaDtos = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(resultSocialMediaDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult SocialMediaCreate()
        {
            ViewBag.socialMediaActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
        {
            ViewBag.socialMediaActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/SocialMedias", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("SocialMediaList", "SocialMedia");
            }

            return RedirectToAction("SocialMediaList", "SocialMedia");
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaUpdate(int id)
        {
            ViewBag.socialMediaActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/SocialMedias/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateSocialMediaDto = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                return View(updateSocialMediaDto);
            }

            return RedirectToAction("SocialMediaList", "SocialMedia");
        }

        [HttpPost]
        public async Task<IActionResult> SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
        {
            ViewBag.socialMediaActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/SocialMedias", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("SocialMediaList", "SocialMedia");
            }

            return RedirectToAction("SocialMediaList", "SocialMedia");
        }

        public async Task<IActionResult> SocialMediaDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/SocialMedias/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("SocialMediaList", "SocialMedia");
            }

            return RedirectToAction("SocialMediaList", "SocialMedia");
        }
    }
}