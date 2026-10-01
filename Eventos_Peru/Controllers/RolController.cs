using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RolController(IRolService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idRol:int:min(1)}")]
    public async Task<IActionResult> GetById(int idRol)
    {
        var entity = await service.GetById(idRol);
        return entity == null ? NotFound() : Ok(entity);
    }
}
