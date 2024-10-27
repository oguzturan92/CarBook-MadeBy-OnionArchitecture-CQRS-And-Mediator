using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ContactList()
        {
            ViewBag.contactActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Contacts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultContactDtos = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(resultContactDtos);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ContactUpdate(int id)
        {
            ViewBag.contactActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Contacts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateContactDto = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(updateContactDto);
            }

            return RedirectToAction("ContactList", "Contact");
        }

        [HttpPost]
        public async Task<IActionResult> ContactUpdate(UpdateContactDto updateContactDto)
        {
            ViewBag.contactActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Contacts", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("ContactList", "Contact");
            }

            return RedirectToAction("ContactList", "Contact");
        }

        public async Task<IActionResult> ContactDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Contacts/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("ContactList", "Contact");
            }

            return RedirectToAction("ContactList", "Contact");
        }
    }
}