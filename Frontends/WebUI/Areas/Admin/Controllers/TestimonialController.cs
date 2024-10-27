using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TestimonialList()
        {
            ViewBag.testimonialActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Testimonials");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultTestimonialDtos = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(resultTestimonialDtos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult TestimonialCreate()
        {
            ViewBag.testimonialActive = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            ViewBag.testimonialActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7105/api/Testimonials", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("TestimonialList", "Testimonial");
            }

            return RedirectToAction("TestimonialList", "Testimonial");
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialUpdate(int id)
        {
            ViewBag.testimonialActive = "active";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Testimonials/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var updateTestimonialDto = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(updateTestimonialDto);
            }

            return RedirectToAction("TestimonialList", "Testimonial");
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            ViewBag.testimonialActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Testimonials", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("TestimonialList", "Testimonial");
            }

            return RedirectToAction("TestimonialList", "Testimonial");
        }

        public async Task<IActionResult> TestimonialDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Testimonials/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("TestimonialList", "Testimonial");
            }

            return RedirectToAction("TestimonialList", "Testimonial");
        }
    }
}