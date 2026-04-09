namespace ReservasHotelApi.DTOs;

public class HabitacionDto
{
    public int Id { get; set; }
    public int Numero{get; set;}
    public decimal Precio{get; set;}
    public string Tipo { get; set; } = string.Empty;
    public bool Disponible { get; set; } = true;
}

public class CrearHabitacionDto
{
    public int Numero{get; set;}
    public decimal Precio{get; set;}
    public string Tipo { get; set; } = string.Empty;
    public bool Disponible { get; set; } = true;
}

public class ActualizarrHabitacionDto
{
    public int Numero{get; set;}
    public decimal Precio{get; set;}
    public string Tipo { get; set; } = string.Empty;
    public bool Disponible { get; set; } = true;
}