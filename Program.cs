using Microsoft.EntityFrameworkCore;
using Mission7.Models; // Ensure this matches your namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the mission7Context with SQLite
builder.Services.AddDbContext<mission7Context>(options =>
{
    // Ensure "MovieConnection" matches the name in your appsettings.json
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection"));
});

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// This defines the default route pattern
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();