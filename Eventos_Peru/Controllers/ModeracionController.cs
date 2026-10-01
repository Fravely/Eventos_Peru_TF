using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ModeracionController(IModeracionService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idModeracion:int:min(1)}")]
    public async Task<IActionResult> GetById(int idModeracion)
    {
        var entity = await service.GetById(idModeracion);
        return entity == null ? NotFound() : Ok(entity);
    }
}
