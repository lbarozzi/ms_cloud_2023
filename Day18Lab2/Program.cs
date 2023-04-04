using Day18Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

string uri = builder.Configuration["WebMD5:uri"];


/* appsettings.json
  "WebMD5": {
    "uri": "https://localhost:7261/api/MD5Contoller"
  },
  "cats": {
    "uri": "https://cat-fact.herokuapp.com/facts"
  }
//*/
//
builder.Services.AddHttpClient("Md5", client => {
    client.BaseAddress = new Uri(uri) ;
    client.DefaultRequestHeaders.Add("mytoken", "antanti");
});

//*cat
string caturi = builder.Configuration["cats:uri"];
builder.Services.AddHttpClient("cats", client => {
    client.BaseAddress = new Uri(caturi);
    client.DefaultRequestHeaders.Add("mytoken", "antanti");
});
//*/;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
