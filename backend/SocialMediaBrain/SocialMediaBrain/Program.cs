using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using SocialMediaBrain.DaoManagers;
using SocialMediaBrain.DatabaseFirstApproach;
using SocialMediaBrain.GenericDao;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.Managers;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<SocialMediaBrainContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SocialMediaBrainContext") 
    ?? throw new InvalidOperationException("Connection string 'SocialMediaBrainContext' not found.")));*/

builder.Services.AddDbContext<TestContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("SocialMediaBrainContext")
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
builder.Services.AddScoped<IUserManager,UserManager>();
builder.Services.AddScoped<IRelationshipManager, RelationshipManager>();
builder.Services.AddScoped(typeof(IGenericDao<>),typeof(GenericDao<>));
builder.Services.AddTransient<IUserDaoManager, UserDaoManager>();

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
