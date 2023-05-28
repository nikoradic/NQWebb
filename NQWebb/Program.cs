using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NQWebb.Data;
using NQWebb.Helpers.Repositories;
using NQWebb.Helpers.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));


builder.Services.AddScoped<ProductEntityRepo>();
builder.Services.AddScoped<ContactFormRepo>();


builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<UserService>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 4;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireDigit = false;
    x.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<ApplicationDbContext>();



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
