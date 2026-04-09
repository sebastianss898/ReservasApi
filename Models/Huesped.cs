namespace ReservasHotelApi.Models;

using System.ComponentModel.DataAnnotations;

public class Huesped
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string? Telefono { get; set; }
}