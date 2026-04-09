namespace ReservasHotelApi.Services;

using ReservasHotelApi.DTOs;
using ReservasHotelApi.Models;
using ReservasHotelApi.Repositories;

public class HabitacionService
{
    private readonly Repository<Habitacion>  _repo;
    public HabitacionService(Repository<Habitacion> repo)
    {
        _repo = repo;
    }

    private HabitacionDto ToDto(Habitacion h) => new HabitacionDto
    {
        Id = h.Id,
        Numero = h.Numero,
        Precio = h.Precio,
        Tipo = h.Tipo,
        Disponible = h.Disponible
    };


    public async Task<List<HabitacionDto>> GetAll()
    {
        var Habitaciones = await _repo.GetAll();
        return Habitaciones.Select(ToDto).ToList();
    }

    public async Task<HabitacionDto?> GetById(int id)
    {
        var habitacion = await _repo.GetById(id);
        return habitacion is null ? null : ToDto(habitacion);
    }

    public async Task<(bool success, string error, HabitacionDto? dto)> Crear(CrearHabitacionDto dto)
    {
        var habitacion = new Habitacion
        {
            Numero = dto.Numero,
            Precio = dto.Precio,
            Tipo = dto.Tipo,
            Disponible =dto.Disponible
        };
        await _repo.Add(habitacion);
        return (true, string.Empty, ToDto(habitacion));
    }

    public async Task<bool> Eliminar(int id)
    {
        var habitacion = await _repo.GetById(id);
        if(habitacion is null) return false;

        await _repo.Delete(habitacion);
        return true;
    }

    public async Task<HabitacionDto?> Actualizar(int id, ActualizarrHabitacionDto dto)
    {
        var habitacion = await _repo.GetById(id);
        if(habitacion is null) return null;

        habitacion.Numero = dto.Numero;
        habitacion.Precio = dto.Precio;
        habitacion.Tipo = dto.Tipo;
        habitacion.Disponible =dto.Disponible;

        await _repo.SaveChanges();
        return ToDto(habitacion);
    }

}