﻿using Microsoft.AspNetCore.Mvc;

namespace WebNotebook.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
