using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ExerciseXData_UserLibrary.Data;
using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Repositories;
using ExerciseXData_DietLibrary.Services;
using ExerciseXData_ExerciseLibrary.Services;
using ExerciseXData_UserLibrary.Services;
using ExerciseXData_UserLibrary.Repositories;
using ExerciseXData_UserLibrary.Models;
using ExerciseXData.Utilities;
using ExerciseXData_ExerciseLibrary.Repositories;
using ExerciseXData.Admin;
using ExerciseXData_SharedContracts.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_ExerciseLibrary.Utilities;
using ExerciseXData_DietLibrary.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*DefaultConnection is set from appsettings.json*/
//DbContext configuration
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlternateConnection")));


builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection"),
    b => b.MigrationsAssembly("ExerciseXData_UserLibrary")));

builder.Services.AddDbContext<ExerciseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExerciseConnection"),
    b => b.MigrationsAssembly("ExerciseXData_ExerciseLibrary")));

builder.Services.AddDbContext<DietDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DietConnection"),
    b => b.MigrationsAssembly("ExerciseXData_DietLibrary")));


builder.Services.AddIdentity<UsersModel, IdentityRole>(options =>
{
    // Password validation settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false; // Allow alphanumeric-only passwords
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    // Lockout settings
    options.Lockout.MaxFailedAccessAttempts = 5;  // Lockout after 5 failed attempts
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);  // Lockout for 15 minutes
    options.Lockout.AllowedForNewUsers = true;  // Enable lockout for new users

    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<UserDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<UsersModel>>();
builder.Services.AddScoped<SignInManager<UsersModel>>();
builder.Services.AddScoped<ILogger<UsersRepository>, Logger<UsersRepository>>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Redirect to login page
        options.LogoutPath = "/Admin/Logout"; // Logout endpoint
    });

//Service
builder.Services.AddScoped<AuthService>(); 
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<DietsService>();
builder.Services.AddScoped<ExercisesService>();
builder.Services.AddScoped<UsersService>();

//Interface
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IExerciseRepository, ExercisesRepository>();
builder.Services.AddScoped<IDietRepository, DietsRepository>();

//Repository
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<DietsRepository>();
builder.Services.AddScoped<ExercisesRepository>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //var configuration = services.GetRequiredService<IConfiguration>();

    var userDbContext = services.GetRequiredService<UserDbContext>();
    await userDbContext.Database.MigrateAsync(); // Apply migrations for UserDbContext
    // Optionally call a seeding method if needed, e.g. SeedUserData(userDbContext);

    // Seed data for ExerciseDbContext
    var exerciseDbContext = services.GetRequiredService<ExerciseDbContext>();
    await exerciseDbContext.Database.MigrateAsync(); // Apply migrations for ExerciseDbContext
    // Optionally call a seeding method if needed, e.g. SeedExerciseData(exerciseDbContext);

    // Seed data for DietDbContext
    var dietDbContext = services.GetRequiredService<DietDbContext>();
    await dietDbContext.Database.MigrateAsync();  // Ensures migrations are applied
                                                  // Seeder will automatically run if migrations are applied
                                                  //await DataSeeder.SeedRoles(services);
                                                  //await DataSeeder.SeedAdminAccount(services, configuration);

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}");

app.Run();
