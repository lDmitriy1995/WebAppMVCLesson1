using WebAppMVCLesson1.Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAppMVCLesson1.Admin.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<WebAppMVCLesson1DbContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("DefaultConnection")));

builder.Services.Configure<customOptionsConfiguration>(builder.Configuration.GetSection("customOptions"));



// Это внедрение зависимости  с сопоставлением типа службы с типом реализации
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddSingleton<IStorage, Storage>();
//Это внедрение зависимости для одного типа
builder.Services.AddTransient<ProductSum>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
