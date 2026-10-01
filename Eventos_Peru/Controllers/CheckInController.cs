using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CheckInController(ICheckInService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idCheckIn:int:min(1)}")]
    public async Task<IActionResult> GetById(int idCheckIn)
    {
        var entity = await service.GetById(idCheckIn);
        return entity == null ? NotFound() : Ok(entity);
    }
}
