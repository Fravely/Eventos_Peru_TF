using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class CompraService(ICompraRepository repository) : ICompraService
{
    private static CompraDTO Map(Compra e) => new()
    {
        IdCompra = e.IdCompra,
        IdUsuario = e.IdUsuario,
        CodigoOperacion = e.CodigoOperacion,
        FechaCompra = e.FechaCompra,
        MontoTotal = e.MontoTotal,
        Estado = e.Estado
    };
    public async Task<IEnumerable<CompraDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<CompraDTO?> GetById(int idCompra)
    {
        var entity = await repository.GetById(idCompra);
        return entity == null ? null : Map(entity);
    }
}
