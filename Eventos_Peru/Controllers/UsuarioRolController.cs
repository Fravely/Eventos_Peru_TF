using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsuarioRolController(IUsuarioRolService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idUsuario:int:min(1)}/{idRol:int:min(1)}")]
    public async Task<IActionResult> GetById(int idUsuario, int idRol)
    {
        var entity = await service.GetById(idUsuario, idRol);
        return entity == null ? NotFound() : Ok(entity);
    }
}
