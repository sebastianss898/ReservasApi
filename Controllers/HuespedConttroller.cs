namespace ReservasHotelApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using ReservasHotelApi.Services;
using ReservasHotelApi.DTOs;

[ApiController]
[Route("/Huespedes")]

public class HuespedController :ControllerBase
{
    public readonly HuespedService _service;

    public HuespedController(HuespedService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var huesped = await _service.GetById(id);
        return huesped is null ? NotFound() : Ok(huesped);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearHuespedDto dto)
    {
        var (success, error, huesped) = await _service.Crear(dto);
        if (!success) return BadRequest(error);
        return Created($"/huespedes/{huesped!.Id}", huesped);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _service.Eliminar(id);
        return eliminado ? NoContent() : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>  Actualizar(int id, ActualizarHuespedDto dto)
    {
        var huesped = await _service.Actualizar(id, dto);
        return huesped is null ? NotFound() : Ok(huesped);
    }

}