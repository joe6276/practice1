using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductAPIDB.Data;
using ProductAPIDB.Models;
using ProductAPIDB.Services;
using ProductAPIDB.Services.IServices;
using ProductAPIDB.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database settings
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

builder.Services.AddDbContext<ApplicationAuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("auth"));
});

//configure Jwt Options
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

//add identity Framework
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationAuthContext>();
//automapper settings
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

///register thr services for dependency injection
///

builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IJwt,JwtService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
