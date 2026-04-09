namespace ReservasHotelApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using ReservasHotelApi.Services;
using ReservasHotelApi.DTOs;

[ApiController]
[Route("/Habitaciones")]

public class HbitacionController :ControllerBase
{
    public readonly HabitacionService _service;

    public HbitacionController(HabitacionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var habitacion = await _service.GetById(id);
        return habitacion is null ? NotFound() : Ok(habitacion);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearHabitacionDto dto)
    {
        var (success, error, habitacion) = await _service.Crear(dto);
        if (!success) return BadRequest(error);
        return Created($"/Habitaciones/{habitacion!.Id}", habitacion);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _service.Eliminar(id);
        return eliminado ? NoContent() : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>  Actualizar(int id, ActualizarrHabitacionDto dto)
    {
        var habitacion = await _service.Actualizar(id, dto);
        return habitacion is null ? NotFound() : Ok(habitacion);
    }

}