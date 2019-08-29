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
    public class ConfirmEmailChangeModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly SharedCultureLocalizer _loc;
        private readonly string culture;

        public ConfirmEmailChangeModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, SharedCultureLocalizer loc)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _loc = loc;
            culture = System.Globalization.CultureInfo.CurrentCulture.Name;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string email, string code)
        {
            string msg;

            if (userId == null || email == null || code == null)
            {
                return RedirectToPage("/Index", new { culture });
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                msg = _loc.FormattedText("Unable to load user with ID '{0}'.", userId);
                return NotFound(msg);
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                msg = _loc.FormattedText("Error changing email.");
                TempData.Danger(msg);
                return Page();
            }

            // In our UI email and user name are one and the same, so when we update the email
            // we need to update the user name.
            var setUserNameResult = await _userManager.SetUserNameAsync(user, email);
            if (!setUserNameResult.Succeeded)
            {
                msg = _loc.FormattedText("Error changing user name.");
                TempData.Danger(msg);
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            msg = _loc.FormattedText("Thank you for confirming your email change.");
            TempData.Success(msg);
            return Page();
        }
    }
}
