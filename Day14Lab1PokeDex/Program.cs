using Day14Lab1PokeDex.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inject DtaContext
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("local")));


//1: Service cookie configuration
builder.Services.Configure<CookiePolicyOptions>(options => {
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//2: Activate cookie consent
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
