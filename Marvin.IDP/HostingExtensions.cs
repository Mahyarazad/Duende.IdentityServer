using Duende.IdentityServer;
using IdentityServer.DbContexts;
using IdentityServer.Entities;
using IdentityServer.Services;
using Marvin.IDP.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Marvin.IDP;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
        // out of process
        builder.Services.Configure<IISOptions>(iis =>
        {
            iis.AuthenticationDisplayName = "Windows";
            iis.AutomaticAuthentication = false;
        });

        //in process
        builder.Services.Configure<IISServerOptions>(iis =>
        {
            iis.AuthenticationDisplayName = "Windows";
            //disable IIS integration layer configuring a windows authenrication handler that can be invoked via an authetication service
            iis.AutomaticAuthentication = false;
        });

        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("IdentityDbContext"));
        });

        builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        builder.Services.AddScoped<IDbUserService, DbUserService>();

        builder.Services.AddIdentityServer(options =>
        {
            // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
            options.EmitStaticAudienceClaim = true;
        })
            .AddProfileService<LocalUserProfileService>()
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients);

        builder.Services.AddAuthentication().AddGoogle(options => {
            options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            options.ClientId = "**";
            options.ClientSecret = "**";
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
