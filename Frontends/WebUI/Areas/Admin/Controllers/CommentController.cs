using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontends.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CommentList(int blogId)
        {
            ViewBag.commentActive = "active";
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7105/api/Comments/CommentListByBlogId/" + blogId);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var resultCommentDtos = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(resultCommentDtos);
            }

            return View();
        }

        // [HttpGet]
        // public IActionResult CommentCreate()
        // {
        //     ViewBag.commentActive = "active";

        //     return View();
        // }

        // [HttpPost]
        // public async Task<IActionResult> CommentCreate(CreateCommentDto createCommentDto)
        // {
        //     ViewBag.commentActive = "active";

        //     var client = _httpClientFactory.CreateClient();

        //     var jsonData = JsonConvert.SerializeObject(createCommentDto);
        //     StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //     var responseMessage = await client.PostAsync("https://localhost:7105/api/Comments", stringContent);
        //     if (responseMessage.IsSuccessStatusCode)
        //     {
        //         TempData["icon"] = "success";
        //         TempData["text"] = "İşlem başarılı.";
        //         return RedirectToAction("CommentList", "Comment");
        //     }

        //     return RedirectToAction("CommentList", "Comment");
        // }

        // [HttpGet]
        // public async Task<IActionResult> CommentUpdate(int id)
        // {
        //     ViewBag.commentActive = "active";

        //     var client = _httpClientFactory.CreateClient();

        //     var responseMessage = await client.GetAsync("https://localhost:7105/api/Comments/" + id);
        //     if (responseMessage.IsSuccessStatusCode)
        //     {
        //         var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //         var updateCommentDto = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
        //         return View(updateCommentDto);
        //     }

        //     return RedirectToAction("CommentList", "Comment");
        // }

        // [HttpPost]
        // public async Task<IActionResult> CommentUpdate(UpdateCommentDto updateCommentDto)
        // {
        //     ViewBag.commentActive = "active";

        //     var client = _httpClientFactory.CreateClient();

        //     var jsonData = JsonConvert.SerializeObject(updateCommentDto);
        //     StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
        //     var responseMessage = await client.PutAsync("https://localhost:7105/api/Comments", stringContent);
            
        //     if (responseMessage.IsSuccessStatusCode)
        //     {
        //         TempData["icon"] = "success";
        //         TempData["text"] = "İşlem başarılı.";
        //         return RedirectToAction("CommentList", "Comment");
        //     }

        //     return RedirectToAction("CommentList", "Comment");
        // }

        public async Task<IActionResult> CommentDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7105/api/Comments/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("CommentList", "Comment");
            }

            return RedirectToAction("CommentList", "Comment");
        }
    }
}