﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}