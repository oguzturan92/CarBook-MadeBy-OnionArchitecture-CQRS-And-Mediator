﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.homeActive = "active";
        return View();
    }
}
