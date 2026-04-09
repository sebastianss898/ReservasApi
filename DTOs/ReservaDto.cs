// Lo que RETORNA la API
public class ReservaDto
{
    public int Id { get; set; }
    public string HabitacionNumero { get; set; } = string.Empty; // dato útil
    public string HuespedNombre { get; set; } = string.Empty;    // dato útil
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public decimal PrecioTotal { get; set; }  // dato calculado útil
}

// Lo que recibe el POST - solo ids y fechas
public class CrearReservaDto
{
    public int HabitacionId { get; set; }
    public int HuespedId { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
}

// Lo que recibe el PUT - solo fechas (no cambias habitación ni huésped)
public class ActualizarReservaDto
{
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
}