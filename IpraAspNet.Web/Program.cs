using IpraAspNet.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IpraAspNet.Application.AuthenticationService;
using IpraAspNet.Application.AuthorizeService.Concrete;
using IpraAspNet.Application.AuthorizeService.Interface;
using IpraAspNet.Application.UserService.Concrete;
using IpraAspNet.Application.UserService.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile("appsettings.Development.json");

builder.Services.AddDbContext<IpraContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

//Ldap
builder.Services.Configure<LdapConfig>(builder.Configuration.GetSection("ldap"));

//Объявление сервисов
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<ILdapAuthenticationService, LdapAuthenticationService>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ipra", Version = "v1" });
});

//Авторизация через куки
builder.Services.AddAuthentication("CookieAuthentication")
     .AddCookie("CookieAuthentication", config =>
     {
         config.ExpireTimeSpan = TimeSpan.FromHours(72);
         config.Cookie.Name = "UserLoginCookie";
         config.LoginPath = "/Authorization/Login";
         config.AccessDeniedPath = new PathString("/Authorization/Login");

     });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();