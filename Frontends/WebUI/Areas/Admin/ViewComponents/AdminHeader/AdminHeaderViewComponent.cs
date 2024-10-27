using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.AdminHeader
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}