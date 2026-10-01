using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NotificacionController(INotificacionService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idNotificacion:int:min(1)}")]
    public async Task<IActionResult> GetById(int idNotificacion)
    {
        var entity = await service.GetById(idNotificacion);
        return entity == null ? NotFound() : Ok(entity);
    }
}
