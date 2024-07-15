using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontends.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            ViewBag.contactActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(CreateContactDto createContactDto)
        {
            createContactDto.ContactDate = DateTime.Now;

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "Mesajınız alındı.";
                return RedirectToAction("Index", "Contact");
            }
            return View();
        }
    }
}