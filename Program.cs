global using ReservasHotelApi.Models;
global using ReservasHotelApi.Data;
global using ReservasHotelApi.DTOs;

using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ReservasHotelApi.Repositories;
using ReservasHotelApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<HotelContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra Repository y Service
builder.Services.AddScoped(typeof(Repository<>), typeof(Repository<>)); // 👈 genérico
builder.Services.AddScoped<HabitacionService>();
builder.Services.AddScoped<HuespedService>();
builder.Services.AddScoped<ReservaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
