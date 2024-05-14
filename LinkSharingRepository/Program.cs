using LinkSharingRepository;
using LinkSharingRepository.Interfaces;
using LinkSharingRepository.Models;
using LinkSharingRepository.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SQLiteContext>();
builder.Services.AddScoped<ILinkSharingRepository, LinkSharingSQLiteRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();


app.MapDelete("/customlinks/delete/{linkId:int}", async (int linkId, [FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    var result = await linkSharingRepository.RemoveCustomLink(linkId);
    return result ? Results.Ok(true) : Results.NotFound(false);
  
}).WithName("DeleteCustomLink")
.WithOpenApi().Produces(200).Produces(404);

app.MapPost("customlinks/add", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] LinkInfo link) =>
{
    return await linkSharingRepository.CreateCustomLink(link.PlatformId, link.UserId, link.LinkUrl);

}).WithName("AddCustomLink")
.WithOpenApi().Produces(200);

app.MapPut("customlinks/update/{linkId:int}", async (int linkId,[FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] CustomLinkUrl linkUrl) =>
{
    var updateLink= await linkSharingRepository.UpdateCustomLink(linkId, linkUrl.linkUrl);
    return updateLink != null ? Results.Ok(updateLink) : Results.NotFound(null);

}).WithName("UpdateCustomLink")
.WithOpenApi().Produces(200).Produces(404); 

app.MapGet("/customlinks/{userId}", async (int userId,[FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    return await linkSharingRepository.GetCustomLinks(userId);

}).WithName("GetLinks")
.WithOpenApi().Produces(200);

app.MapGet("/platforms", async ([FromServices]ILinkSharingRepository linkSharingRepository) =>
{
    return await linkSharingRepository.GetPlatforms();

}).WithName("GetPlatforms")
.WithOpenApi().Produces(200);

app.MapPost("/platforms/add", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] Platform platform) =>
{
    return await linkSharingRepository.AddPlatform(platform);
}).Produces(200);

app.MapPut("/platforms/update", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] Platform platform) =>
{
    var updatedPlatfrm = await linkSharingRepository.UpdatePlatform(platform);
    return updatedPlatfrm;
}).WithName("UpdatePlatform")
.WithOpenApi().Produces(200);

app.MapPost("/users/add", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] AddUserInfo user) =>
{
    var dbUser = await linkSharingRepository.CreateUser(user.firstName,user.surname,user.email, user.password);
    return dbUser;
}).WithName("AddUser")
.WithOpenApi().Produces(200);

app.MapPut("/users/update", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] User user) =>
{
    var updatedUser = await linkSharingRepository.UpdateUser(user.Id,user.FirstName,user.Surname,user.Email,user.Photo,user.PhotoFormat);
    return updatedUser!=null ? Results.Ok(updatedUser) : Results.NotFound(null);
}).WithName("UpdateUser")
.WithOpenApi().Produces(200).Produces(404); 

app.MapDelete("/users/delete/{linkId:int}", async (int linkId, [FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    var result = await linkSharingRepository.RemoveUser(linkId);
    return result ? Results.Ok(true) : Results.NotFound(false);

}).WithName("DeleteUser")
.WithOpenApi().Produces(200).Produces(404); 

app.MapGet("/users", async ([FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    return await linkSharingRepository.GetAllUsers();

}).WithName("GetAllUsers")
.WithOpenApi().Produces(200);

app.MapGet("/users/user/{userId}", async ([FromServices] ILinkSharingRepository linkSharingRepository,
                                              int userId) =>
{
    var user = await linkSharingRepository.GetUser(userId);
    return user != null ? Results.Ok(user) : Results.NotFound(user);

}).WithName("GetUser")
.WithOpenApi().Produces(200).Produces(404);

app.MapGet("/users/getauthenticateduser", async (HttpContext httpContext,[FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    if (httpContext.User.Identity.IsAuthenticated)
    {
        var email = httpContext.User.FindFirstValue(ClaimTypes.Name);
        var user = await linkSharingRepository.GetUser(email);
        return user != null ? Results.Ok(user) : Results.NotFound(httpContext.User);
    }
    return Results.Unauthorized();

}).WithName("GetAuthenticatedUser")
.WithOpenApi().Produces(200).Produces(401).Produces(404);

app.MapPost("/users/login", async (HttpContext httpContext,[FromServices] ILinkSharingRepository linkSharingRepository,
                                               String? username, String? password) =>
{
    var user = await linkSharingRepository.GetAuthenticatedUser(username, password);
    if (user != null)
    {
        var claim = new Claim(ClaimTypes.Name, user.Email);
        var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await httpContext.SignInAsync(claimsPrincipal);
        return Results.Ok(user);
    }

    return Results.Unauthorized();
}).WithName("UserLogin")
.WithOpenApi().Produces(200).Produces(401);

app.MapGet("/users/logout", async (HttpContext httpContext) =>
{
    await httpContext.SignOutAsync();
    return Results.Ok();
}).WithName("UserLogout")
.WithOpenApi().Produces(200);

app.Run();
record CustomLinkUrl (string linkUrl);
record UserAuthDetails (string username, String password);
record AddUserInfo(string firstName, string surname, string password, string email);
record DeleteUserInfo(string email, String password);
record LinkInfo (int PlatformId, int UserId,string LinkUrl);