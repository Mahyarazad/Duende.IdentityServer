using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using IdentityModel;
using IdentityServer.Services;
using Marvin.IDP.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.User.Registration
{
    [AllowAnonymous]
    [SecurityHeaders]
    public class IndexModel : PageModel
    {
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly IDbUserService _dbUserService;

        public IndexModel(IIdentityServerInteractionService interactionService, IDbUserService dbUserService)
        {
            _interactionService = interactionService ?? throw new ArgumentNullException(nameof(interactionService));
            _dbUserService = dbUserService ?? throw new ArgumentNullException(nameof(dbUserService));
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public IActionResult OnGet(string returnUrl)
        {
            BuildModel(returnUrl);
            return Page();
        }

        private void BuildModel(string returnUrl)
        {
            Input = new InputModel()
            {
                ReturnUrl = returnUrl,
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                BuildModel(Input.ReturnUrl);
                return Page();
            }

            var userToCreate = new Entities.User
            {
                Active = false,
                UserName = Input.Username,
                Email = Input.Email,
                Subject = Guid.NewGuid().ToString(),
            };

            userToCreate.UserClaims.Add(new Entities.UserClaim
            {
                Type = "country",
                Value = Input.Country
            });

            userToCreate.UserClaims.Add(new Entities.UserClaim
            {
                Type = JwtClaimTypes.GivenName,
                Value = Input.GivenName 
            });

            userToCreate.UserClaims.Add(new Entities.UserClaim
            {
                Type = JwtClaimTypes.FamilyName,
                Value = Input.FamilyName
            });

            _dbUserService.AddUser(userToCreate, Input.Password);
            await _dbUserService.SaveChangesAsync();

            var activationLink = Url.PageLink("/user/activation/index", values: new { securityCode = userToCreate.SecurityCode });
            Console.WriteLine(activationLink);
            return LocalRedirect("~/User/ActivationCodeSent");


            //Issue auth cookie to login
            //var user = new IdentityServerUser(userToCreate.Subject)
            //{
            //    DisplayName = Input.Username,
            //};

            ////await HttpContext.SignInAsync(user);

            //if(_interactionService.IsValidReturnUrl(Input.ReturnUrl) || Url.IsLocalUrl(Input.ReturnUrl))
            //{
            //    return Redirect(Input.ReturnUrl);
            //}

            //return Redirect("~/");
        }
    }
}
