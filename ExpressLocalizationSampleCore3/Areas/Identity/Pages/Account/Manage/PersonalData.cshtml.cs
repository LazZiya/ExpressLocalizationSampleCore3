using System.Threading.Tasks;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExpressLocalizationSampleCore3.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly SharedCultureLocalizer _loc;

        public PersonalDataModel(
            UserManager<IdentityUser> userManager,
            ILogger<PersonalDataModel> logger,
            SharedCultureLocalizer loc)
        {
            _userManager = userManager;
            _logger = logger;
            _loc = loc;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                var msg = _loc.FormattedText("Unable to load user with ID '{0}'.", _userManager.GetUserId(User));
                return NotFound(msg);
            }

            return Page();
        }
    }
}