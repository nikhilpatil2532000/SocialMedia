using Microsoft.EntityFrameworkCore;
using SocialMediaBrain.Data;
using SocialMediaBrain.Models;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Mvc;
using SocialMediaBrain.Controllers;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.Managers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SocialMediaBrainContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SocialMediaBrainContext") 
    ?? throw new InvalidOperationException("Connection string 'SocialMediaBrainContext' not found.")));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(JsonOptions => 
{
    JsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IUserManager,UserManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
