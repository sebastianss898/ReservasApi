namespace ReservasHotelApi.Services;

using ReservasHotelApi.DTOs;
using ReservasHotelApi.Models;
using ReservasHotelApi.Repositories;

public class HuespedService
{
    private readonly Repository<Huesped>  _repo;
    public HuespedService(Repository<Huesped> repo)
    {
        _repo = repo;
    }

    private HuespedDto ToDto(Huesped h) => new HuespedDto
    {
        Id = h.Id,
        Nombre = h.Nombre,
        Email = h.Email,
        Telefono = h.Telefono,
    };


    public async Task<List<HuespedDto>> GetAll()
    {
        var huesped = await _repo.GetAll();
        return huesped.Select(ToDto).ToList();
    }

    public async Task<HuespedDto?> GetById(int id)
    {
        var huesped = await _repo.GetById(id);
        return huesped is null ? null : ToDto(huesped);
    }

    public async Task<(bool success, string error, HuespedDto? dto)> Crear(CrearHuespedDto dto)
    {
        var huesped = new Huesped
        {
            Nombre = dto.Nombre,
            Email = dto.Email,
            Telefono = dto.Telefono,
        };
        await _repo.Add(huesped);
        return (true, string.Empty, ToDto(huesped));
    }

    public async Task<bool> Eliminar(int id)
    {
        var huesped = await _repo.GetById(id);
        if(huesped is null) return false;

        await _repo.Delete(huesped);
        return true;
    }

    public async Task<HuespedDto?> Actualizar(int id, ActualizarHuespedDto dto)
    {
        var huesped = await _repo.GetById(id);
        if(huesped is null) return null;

        huesped.Nombre = dto.Nombre;
        huesped.Email = dto.Email;
        huesped.Telefono = dto.Telefono;
        

        await _repo.SaveChanges();
        return ToDto(huesped);
    }

}