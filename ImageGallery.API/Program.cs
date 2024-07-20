using ImageGallery.API.Authorization;
using ImageGallery.API.DbContexts;
using ImageGallery.API.Services;
using ImageGallery.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(configure => configure.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<GalleryContext>(options =>
{
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:ImageGalleryDBConnectionString"]);
});

// register the repository
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthorizationHandler, MustOwnImageHandler>();

// register AutoMapper-related services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // for Postman test
    //.AddJwtBearer();

    //
    //.AddJwtBearer(options =>
    //{
    //    options.Authority = "https://localhost:5001";
    //    options.Audience = "imagegalleryapi";
    //    options.TokenValidationParameters = new()
    //    {
    //        NameClaimType = "given_name",
    //        RoleClaimType = "role",
    //        ValidTypes = new[] { "at+jwt" }
    //    };
    //});
    //

    //AccessTokenType = AccessTokenType.Reference
    //using Reference accesstoken 
    // this middleware supports reference access tokens, also the should be another ApiSecret inside the resources
    .AddOAuth2Introspection(options =>
    {
        options.Authority = "https://localhost:44395";
        options.ClientId = "imagegalleryapi";
        options.ClientSecret = "apisecret";
        options.NameClaimType = "given_name";
        options.RoleClaimType = "role";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserCanAddImage", AuthorizationPolicies.AddImageToGallery());
    options.AddPolicy("ClientApplicationCanWrite", builder => {
        builder.RequireClaim("scope", "imagegalleryapi.write");
    });
    options.AddPolicy("MustOwnImage", builder =>
    {
        builder.RequireAuthenticatedUser();
        builder.AddRequirements(new MustOwnImageRequirement());   
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
