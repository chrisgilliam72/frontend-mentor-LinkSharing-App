using LinkSharingRepository;
using LinkSharingRepository.Interfaces;
using LinkSharingRepository.Models;
using LinkSharingRepository.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapDelete("/customlinks/delete/{linkId:int}", async (int linkId, [FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    var result = await linkSharingRepository.RemoveCustomLink(linkId);
    return result ? Results.Ok(true) : Results.NotFound(false);
  
}).WithName("DeleteCustomLink")
.WithOpenApi();

app.MapPost("customlinks/add", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] LinkInfo link) =>
{
    return await linkSharingRepository.CreateCustomLink(link.PlatformId, link.UserId, link.LinkUrl);

}).WithName("AddCustomLink")
.WithOpenApi();

app.MapGet("/customlinks/{userId}", async (int userId,[FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    return await linkSharingRepository.GetCustomLinks(userId);

}).WithName("GetLinks")
.WithOpenApi();

app.MapGet("/platforms", async ([FromServices]ILinkSharingRepository linkSharingRepository) =>
{
    return await linkSharingRepository.GetPlatforms();

}).WithName("GetPlatforms")
.WithOpenApi();

app.MapPost("/platforms/add", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] Platform platform) =>
{
    return await linkSharingRepository.AddPlatform(platform);
});

app.MapPut("/platforms/update", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] Platform platform) =>
{
    var updatedPlatfrm = await linkSharingRepository.UpdatePlatform(platform);
    return updatedPlatfrm;
}).WithName("UpdatePlatform")
.WithOpenApi();

app.MapPost("/users/add", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] AddUserInfo user) =>
{
    var dbUser = await linkSharingRepository.CreateUser(user.firstName,user.surname,user.email, user.password);
    return dbUser;
}).WithName("AddUser")
.WithOpenApi();

app.MapPut("/users/update", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] User user) =>
{
    var updatedUser = await linkSharingRepository.UpdateUser(user.Id,user.FirstName,user.Surname,user.Email,user.Photo,user.PhotoFormat);
    return updatedUser!=null ? Results.Ok(updatedUser) : Results.NotFound(null);
}).WithName("UpdateUser")
.WithOpenApi();

app.MapDelete("/users/delete/{linkId:int}", async (int linkId, [FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    var result = await linkSharingRepository.RemoveUser(linkId);
    return result ? Results.Ok(true) : Results.NotFound(false);

}).WithName("DeleteUser")
.WithOpenApi();

app.MapGet("/users", async ([FromServices] ILinkSharingRepository linkSharingRepository) =>
{
    return await linkSharingRepository.GetAllUsers();

}).WithName("GetAllUsers")
.WithOpenApi();

app.MapGet("/users/user/{userId}", async ([FromServices] ILinkSharingRepository linkSharingRepository,
                                              int userId) =>
{
    var user = await linkSharingRepository.GetUser(userId);
    return user != null ? Results.Ok(user) : Results.NotFound(user);

}).WithName("GetUser")

.WithOpenApi().Produces(200);

app.MapGet("/users/getauthenticateduser", async ([FromServices] ILinkSharingRepository linkSharingRepository,
                                               String? username, String? password) =>
{
    return await linkSharingRepository.GetAuthenticatedUser(username,password);

}).WithName("GetAuthenticatedUser")
.WithOpenApi().Produces(200);

app.Run();

record UserAuthDetails (string username, String password);
record AddUserInfo(string firstName, string surname, string password, string email);
record DeleteUserInfo(string email, String password);
record LinkInfo (int PlatformId, int UserId,string LinkUrl);