using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNotebook.Controllers
{
    public class VuePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
