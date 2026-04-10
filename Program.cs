global using ReservasHotelApi.Models;
global using ReservasHotelApi.Data;
global using ReservasHotelApi.DTOs;

using Microsoft.EntityFrameworkCore;
using ReservasHotelApi.Repositories;
using ReservasHotelApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // 👈 faltaba esto
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(Repository<>), typeof(Repository<>));
builder.Services.AddScoped<HabitacionService>();
builder.Services.AddScoped<HuespedService>();
builder.Services.AddScoped<ReservaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HotelContext>();
    db.Database.Migrate();
}


app.Run();