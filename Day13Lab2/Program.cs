using Day13Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string cnstring = builder.Configuration.GetConnectionString("sqlite");
builder.Services.AddDbContext<DataContext>(opt=>opt.UseSqlite(cnstring));   

builder.Services.AddLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Bypass Validation dot or comma issue
//https://stackoverflow.com/questions/48066208/mvc-jquery-validation-does-not-accept-comma-as-decimal-separator
var supportedCultures = new[]
{
        new CultureInfo("en-US"),
        new CultureInfo("it-IT"),
};

app.UseRequestLocalization(new RequestLocalizationOptions { 
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
    SupportedCultures = supportedCultures
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
