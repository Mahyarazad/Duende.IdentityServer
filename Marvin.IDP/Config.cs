using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace Marvin.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles",
                "Your role(s)",
                new [] { "role" }),
            new IdentityResource("country",
                "Residency country",
                new [] { "country" })
        };

    public static IEnumerable<ApiResource> ApiResources => new ApiResource[] {
        new ApiResource
        {
            Name = "imagegalleryapi",
            DisplayName = "Image Gallery Api",
            UserClaims = new []
            {
                "role", "country"
            },
            Scopes = { "imagegalleryapi.read", "imagegalleryapi.write", "imagegalleryapi.fullaccess" },
            ApiSecrets = { new Secret("apisecret".ToSha256())}
        }
    };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new("imagegalleryapi.fullaccess"),
                new("imagegalleryapi.write"),
                new("imagegalleryapi.read"),
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new Client()
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenType = AccessTokenType.Reference,
                    AccessTokenLifetime = 120,
                    RedirectUris =
                    {
                        "https://localhost:7184/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7184/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "roles", "imagegalleryapi.read", "imagegalleryapi.write", "country"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequireConsent = true
                }
            };
}