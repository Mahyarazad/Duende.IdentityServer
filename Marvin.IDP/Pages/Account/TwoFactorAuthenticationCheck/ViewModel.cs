using IdentityServer.Entities;

namespace IdentityServer.Pages.Account.TwoFactorAuthenticationCheck
{
    public class UserState
    {
        public Entities.User? User { get; set; }
        public UserSecret? Secret { get; set; }
    }
}
