namespace ReservasHotelApi.Models;

using System.ComponentModel.DataAnnotations;

public class Reserva
{
    public int Id { get; set; }
    public int HabitacionId { get; set; }
    public Habitacion? Habitacion { get; set; }
    public int HuespedId { get; set; }
    public Huesped? Huesped { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
}