using Duende.IdentityServer.Events;
using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityServer.Entities;
using IdentityServer.Services;
using Marvin.IDP.Pages;
using Marvin.IDP.Pages.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Web;
using Telemetry = Marvin.IDP.Pages.Telemetry;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;

namespace IdentityServer.Pages.Account.TwoFactorAuthenticationCheck
{
    [AllowAnonymous]
    [SecurityHeaders]
    public class IndexModel : PageModel
    {
        public record struct CacheQuery(string key, string value);
        private readonly IDbUserService _userService;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

        public IndexModel(IDbUserService userService, IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider, IEventService events)
        {
            _userService = userService;
            _interaction = interaction;
            _schemeProvider = schemeProvider;
            _events = events;
        }

        [BindProperty]
        public InputModel Input { get; set; } = default!;
        public UserState View { get; set; } = new();
        public async Task<IActionResult> OnGet(string? returnUrl)
        {
            var query = HttpContext.Request.Query;

            var user = await _userService.GetUserByUserNameAsync(HttpContext.Request.Query.FirstOrDefault(x => x.Key == "UserName").Value!);
            TempData["User"] = JsonConvert.SerializeObject(user);
            var userSecret = await _userService.GetUserSecretAsync(user!.Subject, "TOTP");
            TempData["UserSecret"] = userSecret.Secret;
            TempData["ReturnUrl"] = JsonConvert
                .SerializeObject(HttpContext.Request.Query.Where(x => x.Key != "UserName").Select(x=> new CacheQuery(x.Key, x.Value)).ToList());
            
            Input = new InputModel
            {
                ReturnUrl = returnUrl
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = JsonConvert.DeserializeObject<Entities.User>((string)TempData["User"]);

                var authenticator = new TwoStepsAuthenticator.TimeAuthenticator();
                if (!authenticator.CheckCode(TempData["UserSecret"]!.ToString(), Input.Code!, user))
                {
                    ModelState.AddModelError("totp", "TOTP is invalid");
                    TempData.Keep();
                    return Page();
                }

                var queryDic = JsonConvert.DeserializeObject<ICollection<CacheQuery>>(TempData["ReturnUrl"].ToString());
                string query = "";
                foreach(var kv in queryDic)
                {
                    query += $"&{kv.key}={kv.value}";
                }

                query = query.Replace("&ReturnUrl=", "");

                Input.ReturnUrl = query;
                var context = await _interaction.GetAuthorizationContextAsync(Input.ReturnUrl);
                await _events.RaiseAsync(new UserLoginSuccessEvent(user!.UserName, user!.Subject, user!.UserName, clientId: context?.Client.ClientId));
                Telemetry.Metrics.UserLogin(context?.Client.ClientId, IdentityServerConstants.LocalIdentityProvider);

                // only set explicit expiration here if user chooses "remember me". 
                // otherwise we rely upon expiration configured in cookie middleware.
                var props = new AuthenticationProperties();
                //if (LoginOptions.AllowRememberLogin && Input.RememberLogin)
                //{
                //    props.IsPersistent = true;
                //    props.ExpiresUtc = DateTimeOffset.UtcNow.Add(LoginOptions.RememberMeLoginDuration);
                //};

                // issue authentication cookie with subject ID and username
                var isuser = new IdentityServerUser(user!.Subject)
                {
                    DisplayName = user!.UserName
                };

                await HttpContext.SignInAsync(isuser, props);

                if (context != null)
                {
                    // This "can't happen", because if the ReturnUrl was null, then the context would be null
                    ArgumentNullException.ThrowIfNull(Input.ReturnUrl, nameof(Input.ReturnUrl));

                    if (context.IsNativeClient())
                    {
                        // The client is native, so this change in how to
                        // return the response is for better UX for the end user.
                        return this.LoadingPage(Input.ReturnUrl);
                    }

                    // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                    return Redirect(Input.ReturnUrl ?? "~/");
                }
                // request for a local page
                if (Url.IsLocalUrl(Input.ReturnUrl))
                {
                    return Redirect(Input.ReturnUrl);
                }
                else if (string.IsNullOrEmpty(Input.ReturnUrl))
                {
                    return Redirect("~/");
                }
                else
                {
                    // user might have clicked on a malicious link - should be logged
                    throw new ArgumentException("invalid return URL");
                }
            }

            return Page();
        }
    }
}
