using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.AuthorDtos;
using Frontends.Dtos.BlogDtos;
using Frontends.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BlogList()
        {
            ViewBag.blogActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Blogs");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultBlogDtos = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
                return View(resultBlogDtos);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BlogCreate()
        {
            ViewBag.blogActive = "active";

            var client = _httpClientFactory.CreateClient();

            CreateBlogDto createBlogDto = new();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Authors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                createBlogDto.ResultAuthorDtos = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7105/api/Categories");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                createBlogDto.ResultCategoryDtos = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(createBlogDto);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogCreate(CreateBlogDto createBlogDto)
        {
            ViewBag.blogActive = "active";

            var client = _httpClientFactory.CreateClient();

            createBlogDto.BlogDate = DateTime.Now;

            var jsonData = JsonConvert.SerializeObject(createBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7105/api/Blogs", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BlogList", "Blog");
            }

            return RedirectToAction("BlogList", "Blog");
        }

        [HttpGet]
        public async Task<IActionResult> BlogUpdate(int id)
        {
            ViewBag.blogActive = "active";

            var client = _httpClientFactory.CreateClient();

            UpdateBlogDto updateBlogDto = new();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Blogs/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                updateBlogDto = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
            } else
            {
                return RedirectToAction("BlogList", "Blog");
            }

            var responseMessage1 = await client.GetAsync("https://localhost:7105/api/Authors");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                updateBlogDto.ResultAuthorDtos = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
            } else
            {
                return RedirectToAction("BlogList", "Blog");
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7105/api/Categories");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                updateBlogDto.ResultCategoryDtos = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(updateBlogDto);
            }

            return RedirectToAction("BlogList", "Blog");
        }

        [HttpPost]
        public async Task<IActionResult> BlogUpdate(UpdateBlogDto updateBlogDto)
        {
            ViewBag.blogActive = "active";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            var responseMessage = await client.PutAsync("https://localhost:7105/api/Blogs", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BlogList", "Blog");
            }

            return RedirectToAction("BlogList", "Blog");
        }

        public async Task<IActionResult> BlogDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Blogs/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BlogList", "Blog");
            }

            return RedirectToAction("BlogList", "Blog");
        }
    }
}