using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Services;
using ExerciseXDataLibrary.Data;
using ExerciseXDataLibrary.Repositories;
using ExerciseXDataLibrary.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlternateConnection")));

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ExerciseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<DietDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<DietsService>();
builder.Services.AddScoped<ExercisesService>();
builder.Services.AddScoped<UsersService>();

builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<DietsRepository>();
builder.Services.AddScoped<ExercisesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();