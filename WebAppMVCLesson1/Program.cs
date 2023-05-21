using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Net.NetworkInformation;
using WebAppMVCLesson1.Middleware;
using WebAppMVCLesson1.Models;

int userCount = 0;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EFContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));





//1-я часть
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Home/Login";
        option.ExpireTimeSpan= TimeSpan.FromMinutes(15);
        option.Cookie.Name = ".HotelATR.Cookies";
        option.SlidingExpiration = true;
    });



builder.Host.ConfigureLogging(logingBuilder =>
{
    logingBuilder.ClearProviders();
    //logingBuilder
    //      .AddSeq()
    //    .AddDebug()
    //    .AddEventLog()
    //    .AddConsole();

    var columnOptions = new ColumnOptions
    {
        AdditionalColumns = new Collection<SqlColumn>
                {
                new SqlColumn("UserName", SqlDbType.VarChar),
                new SqlColumn("IP", SqlDbType.VarChar)
               }
    };


    //builder.Host.UseSerilog();
    //Log.Logger = new LoggerConfiguration()
    //    .WriteTo.Seq("http://localhost:5341/")
    //    .WriteTo.Debug(new RenderedCompactJsonFormatter())
    //    .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
    //    .WriteTo.MSSqlServer(
    //    builder.Configuration["ConnectionStrings:DefaultConnection"],
    //    sinkOptions: new MSSqlServerSinkOptions { TableName = "Log" },
    //    null,
    //    null,
    //    LogEventLevel.Information,
    //    null,
    //    columnOptions,
    //    null,
    //    null)
    //    .CreateLogger();
});

var app = builder.Build();

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(),
                     "wwwroot", 
                     "img")), 
    RequestPath = "/images"
}); 

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

//2-я часть 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();