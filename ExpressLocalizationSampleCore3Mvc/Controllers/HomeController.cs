﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExpressLocalizationSampleCore3Mvc.Models;
using LazZiya.ExpressLocalization;
using LazZiya.TagHelpers.Alerts;

namespace ExpressLocalizationSampleCore3Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        // To localize backend strings inject SahredCultureLocalizer
        private readonly SharedCultureLocalizer _loc;

        public HomeController(ILogger<HomeController> logger, SharedCultureLocalizer loc)
        {
            _logger = logger;
            _loc = loc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // This is a sample to show how to localize 
            // custom messages from the backend.
            // The texts must be defined in ViewsLocalizationResource.xx.resx
            var msg = _loc.GetLocalizedString("Privacy Policy");
            
            // Use AlertTagHelper to show messages
            // Available options : .Success .Warning .Danger .Info .Dark .Light .Primary .Secondary
            // For more details visit: http://demo.ziyad.info/alert
            TempData.Warning(msg);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
