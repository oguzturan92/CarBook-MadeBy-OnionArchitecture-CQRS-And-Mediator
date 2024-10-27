using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ServiceList()
        {
            ViewBag.serviceActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Services");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultServiceDtos = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(resultServiceDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult ServiceCreate()
        {
            ViewBag.serviceActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCreate(CreateServiceDto createServiceDto)
        {
            ViewBag.serviceActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Services", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("ServiceList", "Service");
            }

            return RedirectToAction("ServiceList", "Service");
        }

        [HttpGet]
        public async Task<IActionResult> ServiceUpdate(int id)
        {
            ViewBag.serviceActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Services/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateServiceDto = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(updateServiceDto);
            }

            return RedirectToAction("ServiceList", "Service");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceUpdate(UpdateServiceDto updateServiceDto)
        {
            ViewBag.serviceActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Services", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("ServiceList", "Service");
            }

            return RedirectToAction("ServiceList", "Service");
        }

        public async Task<IActionResult> ServiceDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Services/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("ServiceList", "Service");
            }

            return RedirectToAction("ServiceList", "Service");
        }
    }
}