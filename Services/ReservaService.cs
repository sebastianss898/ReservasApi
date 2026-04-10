namespace ReservasHotelApi.Services;

using ReservasHotelApi.DTOs;
using ReservasHotelApi.Models;
using ReservasHotelApi.Repositories;

public class ReservaService
{
    private readonly Repository<Reserva> _repo;
    public ReservaService(Repository<Reserva> repo)
    {
        _repo = repo;
    }

    private ReservaDto ToDto(Reserva r) => new ReservaDto
    {
        Id = r.Id,
        HabitacionNumero = r.Habitacion?.Numero.ToString() ?? "N/A",
        HuespedNombre = r.Huesped?.Nombre ?? "N/A",
        FechaEntrada = r.FechaEntrada,   // 👈 tenías FechaSalida aquí
        FechaSalida = r.FechaSalida,
        PrecioTotal = r.Habitacion != null
        ? r.Habitacion.Precio * (decimal)(r.FechaSalida - r.FechaEntrada).TotalDays
        : 0  // precio por día × número de días
    };

    public async Task<List<ReservaDto>> GetAll()
    {
        var reservas = await _repo.GetAll();
        return reservas.Select(ToDto).ToList();
    }

    public async Task<ReservaDto?> GetById(int id)
    {
        var reserva = await _repo.GetById(id);
        return reserva is null ? null : ToDto(reserva);
    }

    public async Task<(bool success, string error, ReservaDto? dto)> Crear(CrearReservaDto dto)
{
    if (dto.FechaSalida <= dto.FechaEntrada)
        return (false, "La fecha de salida debe ser mayor a la de entrada", null);

    if (dto.FechaEntrada < DateTime.UtcNow)
        return (false, "No puedes reservar en el pasado", null);

    // 👇 Validación de disponibilidad
    var reservaExistente = await _repo.FindAsync(r =>
        r.HabitacionId == dto.HabitacionId &&
        r.FechaEntrada < dto.FechaSalida &&
        r.FechaSalida > dto.FechaEntrada);

    if (reservaExistente is not null)
        return (false, "La habitación ya está reservada en esas fechas", null);

    var reserva = new Reserva
    {
        HabitacionId = dto.HabitacionId,
        HuespedId = dto.HuespedId,
        FechaEntrada = dto.FechaEntrada,
        FechaSalida = dto.FechaSalida
    };

    await _repo.Add(reserva);
    return (true, string.Empty, ToDto(reserva));
}

    public async Task<bool> Eliminar(int id)
    {
        var reserva = await _repo.GetById(id);
        if(reserva is null) return false;

        await _repo.Delete(reserva);
        return true;
    }

    public async Task<ReservaDto?> Actualizar(int id, ActualizarReservaDto dto)
    {
        var reserva = await _repo.GetById(id);
        if(reserva is null) return null;

        reserva.FechaEntrada = dto.FechaEntrada;
        reserva.FechaSalida = dto.FechaSalida;

        await _repo.SaveChanges();
        return ToDto(reserva);
    }

}