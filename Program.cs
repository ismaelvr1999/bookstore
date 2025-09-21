using bookstore.Data;
using Microsoft.EntityFrameworkCore;
using bookstore.Models;
// create app builder
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// add services
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();
builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// build app
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// add middlewares
//app.UseStaticFiles();
//app.MapRazorPages();

app.UseHttpsRedirection();
app.UseRouting();
app.MapStaticAssets();

/* app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Foo}/{action=Index}"
).WithStaticAssets();

app.MapControllerRoute(
    name: "Baz",
    pattern: "{controller=Baz}/{action=Index}"
).WithStaticAssets(); */

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}"
).WithStaticAssets();

app.Run();
