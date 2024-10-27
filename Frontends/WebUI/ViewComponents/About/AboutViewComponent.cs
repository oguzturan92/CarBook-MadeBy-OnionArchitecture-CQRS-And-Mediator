using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontends.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.About
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7105/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var getOneAboutDto = JsonConvert.DeserializeObject<GetOneAboutDto>(jsonData);
                return View(getOneAboutDto);
            }
            return View();
        }
    }
}