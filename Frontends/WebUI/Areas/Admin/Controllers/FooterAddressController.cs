using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterAddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterAddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressUpdate()
        {
            ViewBag.footerAddressActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/FooterAddresses");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateFooterAddressDto = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(jsonData);
                return View(updateFooterAddressDto);
            }

            return RedirectToAction("FooterAddressUpdate", "FooterAddress");
        }

        [HttpPost]
        public async Task<IActionResult> FooterAddressUpdate(UpdateFooterAddressDto updateFooterAddressDto)
        {
            ViewBag.footerAddressActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
             HttpResponseMessage responseMessage = new();
            
            // FooterAddressId 0 ise sayfaya veri gitmemiştir ve ilk öge eklemek için PostAsync çalışır
            if (updateFooterAddressDto.FooterAddressId == 0)
            {
                responseMessage = await client.PostAsync("https://localhost:7105/api/FooterAddresses", stringContent);
            } else
            {
                responseMessage = await client.PutAsync("https://localhost:7105/api/FooterAddresses", stringContent);
            }
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("FooterAddressUpdate", "FooterAddress");
            }

            return RedirectToAction("FooterAddressUpdate", "FooterAddress");
        }
        
    }
}