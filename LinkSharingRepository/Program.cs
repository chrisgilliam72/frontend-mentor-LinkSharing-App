using LinkSharingRepository;
using LinkSharingRepository.Interfaces;
using LinkSharingRepository.Models;
using LinkSharingRepository.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SQLiteContext>();
builder.Services.AddScoped<ILinkSharingRepository, LinkSharingSQLiteRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/platforms", async ([FromServices]ILinkSharingRepository linkSharingRepository) =>
{
    return await linkSharingRepository.GetPlatforms();

}).WithName("GetPlatforms")
.WithOpenApi();

app.MapPost("/users/add", async ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody] AddUserInfo user) =>
{
    var dbUser = await linkSharingRepository.CreateUser(user.firstName,user.surname,user.email, user.password);
    return dbUser;
}).WithName("AddUser")
.WithOpenApi();

app.MapDelete("/users/delete", async  ([FromServices] ILinkSharingRepository linkSharingRepository, [FromBody]DeleteUserInfo user) =>
{
    var result = await linkSharingRepository.RemoveUser(user.email, user.password);
    return result;


}).WithName("DeleteUser")
.WithOpenApi();

app.Run();


record AddUserInfo(string firstName, string surname, string password, string email);
record DeleteUserInfo(string email, String password);