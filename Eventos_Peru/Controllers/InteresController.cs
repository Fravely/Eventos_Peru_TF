using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class InteresController(IInteresService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idInteres:int:min(1)}")]
    public async Task<IActionResult> GetById(int idInteres)
    {
        var entity = await service.GetById(idInteres);
        return entity == null ? NotFound() : Ok(entity);
    }
}
