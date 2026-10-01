using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompraController(ICompraService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idCompra:int:min(1)}")]
    public async Task<IActionResult> GetById(int idCompra)
    {
        var entity = await service.GetById(idCompra);
        return entity == null ? NotFound() : Ok(entity);
    }
}
