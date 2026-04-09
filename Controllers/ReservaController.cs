namespace ReservasHotelApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using ReservasHotelApi.Services;
using ReservasHotelApi.DTOs;

[ApiController]
[Route("/reservas")]

public class ReservaController : ControllerBase
{
    public readonly ReservaService _service;

    public ReservaController(ReservaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var reserva = await _service.GetById(id);
        return reserva is null ? NotFound() : Ok(reserva);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearReservaDto dto)
    {
        var (success, error, reserva) = await _service.Crear(dto);
        if (!success) return BadRequest(error);
        return Created($"/reservas/{reserva!.Id}", reserva);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _service.Eliminar(id);
        return eliminado ? NoContent() : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, ActualizarReservaDto dto)
    {
        var reserva = await _service.Actualizar(id, dto);
        return reserva is null ? NotFound() : Ok(reserva);
    }

}