using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsuarioInteresController(IUsuarioInteresService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idUsuario:int:min(1)}/{idInteres:int:min(1)}")]
    public async Task<IActionResult> GetById(int idUsuario, int idInteres)
    {
        var entity = await service.GetById(idUsuario, idInteres);
        return entity == null ? NotFound() : Ok(entity);
    }
}
