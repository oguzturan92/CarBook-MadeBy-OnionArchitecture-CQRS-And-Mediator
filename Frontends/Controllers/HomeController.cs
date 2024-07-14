using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Frontends.Models;

namespace Frontends.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.homeActive = "active";
        return View();
    }
}
