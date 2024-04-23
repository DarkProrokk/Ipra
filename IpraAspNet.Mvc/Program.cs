using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.AuthentificationService;
using ServiceLayer.AuthorizeService.Abstract;
using ServiceLayer.AuthorizeService.Concrete;
using ServiceLayer.UserService.Concrete;
using ServiceLayer.UserService.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile("appsettings.Development.json");

builder.Services.AddDbContext<IpraContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

//Ldap
builder.Services.Configure<LdapConfig>(builder.Configuration.GetSection("ldap"));

// Объявление сервисов
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<ILdapAuthentificationService, LdapAuthentificationService>();



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

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();