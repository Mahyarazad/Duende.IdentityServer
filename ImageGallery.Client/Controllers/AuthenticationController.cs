using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ImageGallery.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AuthenticationController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new Exception(nameof(httpClientFactory));
        }

        [Authorize]
        public async Task Logout()
        {
            var client = httpClientFactory.CreateClient("IDP");

            var documentDiscoveryResponse = await client.GetDiscoveryDocumentAsync();

            if (documentDiscoveryResponse.IsError)
            {
                throw new Exception(documentDiscoveryResponse.Error);
            }

            await client.RevokeTokenAsync(new TokenRevocationRequest
            {
                Address = documentDiscoveryResponse.RevocationEndpoint,
                ClientId = "imagegalleryapi",
                ClientSecret = "secret",
                Token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken)
            });

            await client.RevokeTokenAsync(new TokenRevocationRequest
            {
                Address = documentDiscoveryResponse.RevocationEndpoint,
                ClientId = "imagegalleryapi",
                ClientSecret = "secret",
                Token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken)
            });

            // Clears the  local cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirects to the IDP linked to scheme
            // "OpenIdConnectDefaults.AuthenticationScheme" (oidc)
            // so it can clear its own session/cookie
            await HttpContext.SignOutAsync(
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}