using IdentityModel;
using IdentityServer.Services;
using Marvin.IDP.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using TwoFactorAuthNet;

namespace IdentityServer.Pages.User.MfaRegistration
{
    [Authorize]
    [SecurityHeaders]
    public class IndexModel : PageModel
    {
        private readonly IDbUserService _dbUserService;
        private readonly char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public ViewModel View { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public IndexModel(IDbUserService dbUserService)
        {
            _dbUserService = dbUserService ?? throw new ArgumentNullException(nameof(dbUserService));
        }

        public async Task OnGet()
        {
            var secret = TwoStepsAuthenticator.Authenticator.GenerateKey();
            var subject = User.FindFirst(JwtClaimTypes.Subject)!.Value;
            var user = await _dbUserService.GetUserBySubjectAsync(subject);

            var keyUri = string.Format("otpauth://totp/{0}:{1}?secret={2}&issuer={0}&algorithm=SHA1&digits=16"
                , WebUtility.UrlEncode("IdentityServer"), WebUtility.UrlEncode(user!.Email), secret);

            View = new() { KeyUri = keyUri };   
            Input = new() { Secret = secret };  
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var subject = User.FindFirst(JwtClaimTypes.Subject)!.Value;
                if(await _dbUserService.AddUserSecret(subject, "TOTP", Input.Secret))
                {
                    await _dbUserService.SaveChangesAsync();
                    return Redirect("~/");
                }
                else
                {
                    throw new Exception("MFA Registrtion failed");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}   
