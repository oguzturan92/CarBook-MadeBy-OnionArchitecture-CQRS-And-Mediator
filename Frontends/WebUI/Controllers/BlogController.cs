using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.BlogDtos;
using Dtos.CategoryDtos;
using Dtos.TagCloudDtos;
using Frontends.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.blogActive = "active";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7105/api/Blogs/GetAllBlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.blogActive = "active";

            var client = _httpClientFactory.CreateClient();

            BlogDetailModel blogDetailModel = new()
            {
                Categories = new List<ResultCategoryDto>(),
                Blogs = new List<ResultBlogLast3Dto>(),
                Blog = new GetByIdBlogDto(),
                Tags = new List<GetTagCloudByBlogIdDto>()
            };

            // Kategori
            var responseMessage1 = await client.GetAsync("https://localhost:7105/api/Categories");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                blogDetailModel.Categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            }

            // Son 3 Blog
            var responseMessage = await client.GetAsync("https://localhost:7105/api/Blogs/GetBlogLast3WithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                blogDetailModel.Blogs = JsonConvert.DeserializeObject<List<ResultBlogLast3Dto>>(jsonData);
            }

            // Blog Detay
            var responseMessage2 = await client.GetAsync("https://localhost:7105/api/Blogs/" + id);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                blogDetailModel.Blog = JsonConvert.DeserializeObject<GetByIdBlogDto>(jsonData);
            }

            // Tags
            var responseMessage3 = await client.GetAsync("https://localhost:7105/api/TagClouds/GetTagCloudByBlogId/" + id);
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                blogDetailModel.Tags = JsonConvert.DeserializeObject<List<GetTagCloudByBlogIdDto>>(jsonData);
            }
            
            return View(blogDetailModel);
        }
    }
}