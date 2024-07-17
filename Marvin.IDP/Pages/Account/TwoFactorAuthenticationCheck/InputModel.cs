using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Pages.Account.TwoFactorAuthenticationCheck
{
    public class InputModel
    {
        public string? ReturnUrl { get; set; }
        [Required]
        public string? Code { get; set; }
    }
}
