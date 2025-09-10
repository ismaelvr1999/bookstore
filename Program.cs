using bookstore.Data;
using Microsoft.EntityFrameworkCore;
using bookstore.Models;
// create app builder
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// add services
builder.Services.AddRazorPages();
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
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
