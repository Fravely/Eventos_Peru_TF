using Microsoft.AspNetCore.Mvc;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DetalleCompraController(IDetalleCompraService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAll());
    [HttpGet("{idDetalleCompra:int:min(1)}")]
    public async Task<IActionResult> GetById(int idDetalleCompra)
    {
        var entity = await service.GetById(idDetalleCompra);
        return entity == null ? NotFound() : Ok(entity);
    }
}
