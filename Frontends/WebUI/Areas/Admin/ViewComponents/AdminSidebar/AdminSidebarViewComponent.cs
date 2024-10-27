using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.AdminSidebar
{
    public class AdminSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}