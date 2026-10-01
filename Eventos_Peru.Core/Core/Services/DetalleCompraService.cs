using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class DetalleCompraService(IDetalleCompraRepository repository) : IDetalleCompraService
{
    private static DetalleCompraDTO Map(DetalleCompra e) => new()
    {
        IdDetalleCompra = e.IdDetalleCompra,
        IdCompra = e.IdCompra,
        IdEvento = e.IdEvento,
        Cantidad = e.Cantidad,
        PrecioUnitario = e.PrecioUnitario,
        Subtotal = e.Subtotal
    };
    public async Task<IEnumerable<DetalleCompraDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<DetalleCompraDTO?> GetById(int idDetalleCompra)
    {
        var entity = await repository.GetById(idDetalleCompra);
        return entity == null ? null : Map(entity);
    }
}
