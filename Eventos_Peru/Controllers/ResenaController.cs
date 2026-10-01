using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ResenaController(IResenaService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idResena:int:min(1)}")]
    public async Task<IActionResult> GetById(int idResena)
    {
        var entity = await service.GetById(idResena);
        return entity == null ? NotFound() : Ok(entity);
    }
}
