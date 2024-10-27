using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> FeatureList()
        {
            ViewBag.featureActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Features");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultFeatureDtos = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(resultFeatureDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult FeatureCreate()
        {
            ViewBag.featureActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FeatureCreate(CreateFeatureDto createFeatureDto)
        {
            ViewBag.featureActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Features", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("FeatureList", "Feature");
            }

            return RedirectToAction("FeatureList", "Feature");
        }

        [HttpGet]
        public async Task<IActionResult> FeatureUpdate(int id)
        {
            ViewBag.featureActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Features/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateFeatureDto = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(updateFeatureDto);
            }

            return RedirectToAction("FeatureList", "Feature");
        }

        [HttpPost]
        public async Task<IActionResult> FeatureUpdate(UpdateFeatureDto updateFeatureDto)
        {
            ViewBag.featureActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Features", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("FeatureList", "Feature");
            }

            return RedirectToAction("FeatureList", "Feature");
        }

        public async Task<IActionResult> FeatureDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Features/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("FeatureList", "Feature");
            }

            return RedirectToAction("FeatureList", "Feature");
        }
    }
}