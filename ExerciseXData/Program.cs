using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using ExerciseXData.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

/*DefaultConnection is set from appsettings.json*/
//DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Services configuration
builder.Services.AddScoped<IDietService, DietService>(); 
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IFoodService, FoodService>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}");

app.Run();
