using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazZiya.ExpressLocalization;
using LazZiya.TagHelpers.Alerts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace ExpressLocalizationSampleCore3.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SharedCultureLocalizer _loc;
        private readonly string culture;

        public ConfirmEmailModel(UserManager<IdentityUser> userManager, SharedCultureLocalizer loc)
        {
            _userManager = userManager;
            _loc = loc;
            culture = System.Globalization.CultureInfo.CurrentCulture.Name;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index", new { culture });
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                var msg = _loc.FormattedText("Unable to load user with ID '{0}'.", userId);
                return NotFound(msg);
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                var msg = _loc.FormattedText("Thank you for confirming your email.");
                TempData.Success(msg);
            }
            else
            {
                var msg = _loc.FormattedText("Error confirming your email.");
                TempData.Danger(msg);
            }

            return Page();
        }
    }
}
