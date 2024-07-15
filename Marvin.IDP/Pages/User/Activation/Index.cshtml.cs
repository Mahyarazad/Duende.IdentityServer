using IdentityServer.Services;
using Marvin.IDP.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;

namespace IdentityServer.Pages.User.Activation
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IDbUserService _dbUserService;

        public IndexModel(IDbUserService dbUserService)
        {
            _dbUserService = dbUserService ?? throw new ArgumentNullException();
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public async Task<IActionResult> OnGet(string securityCode)
        {
            Input = new InputModel();
            if (await _dbUserService.ActivateUserAsync(securityCode))
            {
                Input.Message = "Your account was successfully activated. \n Navigate to your client application to login.";
            }
            else
            {
                Input.Message = "Your account couldn't be activated. Please contact your adminstrator.";
            }

            return Page();
        }
    }
}
