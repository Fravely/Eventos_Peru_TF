using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IUsuarioService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idUsuario:int:min(1)}")]
    public async Task<IActionResult> GetById(int idUsuario)
    {
        var entity = await service.GetById(idUsuario);
        return entity == null ? NotFound() : Ok(entity);
    }
}
