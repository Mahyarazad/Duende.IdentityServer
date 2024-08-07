using ImageGallery.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Net.Http.Headers;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()    
        .ReadFrom.Configuration(ctx.Configuration);
});
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(configure => 
        configure.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddAccessTokenManagement();

JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

var configuration = builder.Configuration;

// create an HttpClient used for accessing the API
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri(configuration["ImageGalleryAPIRoot"]!);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
}).AddUserAccessTokenHandler();

builder.Services.AddHttpClient("IDP", client => {
    client.BaseAddress = new Uri(configuration["IDP"]!);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.AccessDeniedPath = "/Authentication/AccessDenied";
})
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = "https://localhost:44395/";
    options.ClientId = "imagegalleryclient";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    //options.Scope.Add("openid");
    //options.Scope.Add("profile");
    //options.CallbackPath = new PathString("signin-oidc");
    // SignedOutCallbackPath: default = host:port/signout-callback-oidc.
    // Must match with the post logout redirect URI at IDP client config if
    // you want to automatically return to the application after logging out
    // of IdentityServer.
    // To change, set SignedOutCallbackPath
    // eg: options.SignedOutCallbackPath = new PathString("pathaftersignout");
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClaimActions.Remove("aud");
    options.ClaimActions.DeleteClaim("sid");
    options.ClaimActions.DeleteClaim("idp");
    options.Scope.Add("country");
    options.Scope.Add("roles");
    options.Scope.Add("imagegalleryapi.read");
    options.Scope.Add("imagegalleryapi.write");
    options.Scope.Add("offline_access");
    options.ClaimActions.MapJsonKey("role", "role");
    options.ClaimActions.MapUniqueJsonKey("country", "country");
    options.TokenValidationParameters = new ()
    {
        NameClaimType = "given_name",
        RoleClaimType = "role",
    };
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("UserCanAddImage", AuthorizationPolicies.AddImageToGallery());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Index}/{id?}");

app.Run();
