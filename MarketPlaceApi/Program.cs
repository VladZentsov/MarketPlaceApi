using MarketPlaceDAL.DBContext;
using MarketPlaceDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MarketPlaceApi.Extensions;
using MarketPlaceDAL.UoW;
using MarketPlaceDAL.Repositories.Interfaces;
using MarketPlaceBLL.Services;
using MarketPlaceBLL.Mapper;
using Microsoft.Extensions.DependencyInjection;
using MarketPlaceDAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    // ...
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
});
builder.Services.AddAuthorization();
//builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme).AddBearerToken(IdentityConstants.BearerScheme);


builder.Services.AddDbContext<MarketPlaceDBContext>(options=>
options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("MarketPlaceApi")
    ));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<MarketPlaceDBContext>()
    .AddApiEndpoints();


//builder.Services.AddIdentity<User, IdentityRole>()
//                .AddEntityFrameworkStores<MarketPlaceDBContext>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ShopService>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));



builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/logout")
    {
        context.Response.Cookies.Delete(".AspNetCore.Identity.Application");
        context.Response.Redirect("/"); // Redirect to home or login page
        return;
    }

    await next();
});

app.MapIdentityApi<User>();

app.Run();
