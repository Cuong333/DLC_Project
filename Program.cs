using DLC_Project.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your DemoDlcContext as a service
builder.Services.AddDbContext<DemoDlcContext>(options =>
{
    // Use the correct connection string or provider (e.g., SQL Server, SQLite, etc.)
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true; // Cookie settings for security
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

// Add distributed memory cache (required for session state)
builder.Services.AddDistributedMemoryCache();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use session middleware
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
