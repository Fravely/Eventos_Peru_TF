using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriaController(ICategoriaService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategorias() => Ok(await service.GetCategorias());
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetCategoriaById(int id)
    {
        var entity = await service.GetCategoriaById(id);
        return entity == null ? NotFound() : Ok(entity);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategoria(CategoriaCreateDTO dto)
    {
        var entity = await service.CreateCategoria(dto);
        return CreatedAtAction(nameof(GetCategoriaById), new { id = entity.IdCategoria }, entity);
    }
    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> UpdateCategoria(int id, CategoriaUpdateDTO dto)
    {
        if (id != dto.IdCategoria) return BadRequest(new { mensaje = "El id de la ruta debe coincidir con el del cuerpo." });
        return await service.UpdateCategoria(dto) ? NoContent() : NotFound();
    }
    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> DeleteCategoria(int id) => await service.DeleteCategoria(id) ? NoContent() : NotFound();
}
