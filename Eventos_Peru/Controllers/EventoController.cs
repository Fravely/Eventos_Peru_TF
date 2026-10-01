using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EventoController(IEventoService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEventos([FromQuery] EventoFiltroDTO filtro) => Ok(await service.GetEventos(filtro));
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetEventoById(int id)
    {
        var entity = await service.GetEventoById(id);
        return entity == null ? NotFound() : Ok(entity);
    }
    [HttpPost]
    public async Task<IActionResult> CreateEvento(EventoCreateDTO dto)
    {
        var entity = await service.CreateEvento(dto);
        return CreatedAtAction(nameof(GetEventoById), new { id = entity.IdEvento }, entity);
    }
    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> UpdateEvento(int id, EventoUpdateDTO dto)
    {
        if (id != dto.IdEvento) return BadRequest(new { mensaje = "El id de la ruta debe coincidir con el del cuerpo." });
        return await service.UpdateEvento(dto) ? NoContent() : NotFound();
    }
    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> DeleteEvento(int id) => await service.DeleteEvento(id) ? NoContent() : NotFound();
}
