namespace ReservasHotelApi.Data;

using ReservasHotelApi.Models;
using Microsoft.EntityFrameworkCore;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }
    public DbSet<Habitacion> Habitaciones { get; set; }
    public DbSet<Huesped> Huespedes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

}