using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EntradaController(IEntradaService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idEntrada:int:min(1)}")]
    public async Task<IActionResult> GetById(int idEntrada)
    {
        var entity = await service.GetById(idEntrada);
        return entity == null ? NotFound() : Ok(entity);
    }
}
