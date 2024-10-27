using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AuthorList()
        {
            ViewBag.authorActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Authors");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultAuthorDtos = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
                return View(resultAuthorDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AuthorCreate()
        {
            ViewBag.authorActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AuthorCreate(CreateAuthorDto createAuthorDto)
        {
            ViewBag.authorActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createAuthorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Authors", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AuthorList", "Author");
            }

            return RedirectToAction("AuthorList", "Author");
        }

        [HttpGet]
        public async Task<IActionResult> AuthorUpdate(int id)
        {
            ViewBag.authorActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Authors/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateAuthorDto = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);
                return View(updateAuthorDto);
            }

            return RedirectToAction("AuthorList", "Author");
        }

        [HttpPost]
        public async Task<IActionResult> AuthorUpdate(UpdateAuthorDto updateAuthorDto)
        {
            ViewBag.authorActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateAuthorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Authors", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AuthorList", "Author");
            }

            return RedirectToAction("AuthorList", "Author");
        }

        public async Task<IActionResult> AuthorDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Authors/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AuthorList", "Author");
            }

            return RedirectToAction("AuthorList", "Author");
        }
    }
}