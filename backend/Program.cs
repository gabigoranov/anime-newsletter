using AnimeNewsletter.Data;
using AnimeNewsletter.Services;
using AnimeNewsletter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL + EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Register HttpClient
builder.Services.AddHttpClient();

// Register Services
builder.Services.AddScoped<IUserAnimeService, UserAnimeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<N8NService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();