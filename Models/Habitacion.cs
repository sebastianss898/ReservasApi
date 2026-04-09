namespace ReservasHotelApi.Models;

using System.ComponentModel.DataAnnotations;

public class Habitacion
{
    public int Id{get; set;}
    public int Numero{get; set;}
    public decimal Precio{get; set;}
    public string Tipo { get; set; } = string.Empty;
    public bool Disponible { get; set; } = true;
}