using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazZiya.ExpressLocalization;
using LazZiya.TagHelpers.Alerts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExpressLocalizationSampleCore3.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        // To localize backend strings inject SahredCultureLocalizer
        private readonly SharedCultureLocalizer _loc;

        public PrivacyModel(ILogger<PrivacyModel> logger, SharedCultureLocalizer loc)
        {
            _logger = logger;
            _loc = loc;
        }

        public void OnGet()
        {
            // This is a sample to show how to localize 
            // custom messages from the backend.
            // The texts must be defined in ViewsLocalizationResource.xx.resx
            var msg = _loc.GetLocalizedString("Privacy Policy");

            // Use AlertTagHelper to show messages
            // Available options : .Success .Warning .Danger .Info .Dark .Light .Primary .Secondary
            // For more details visit: http://demo.ziyad.info/alert
            TempData.Warning(msg);
        }
    }
}
