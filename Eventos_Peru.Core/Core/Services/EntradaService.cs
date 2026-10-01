using Eventos_Peru.Core.Core.DTOs;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
namespace Eventos_Peru.Core.Core.Services;
public class EntradaService(IEntradaRepository repository) : IEntradaService
{
    private static EntradaDTO Map(Entrada e) => new()
    {
        IdEntrada = e.IdEntrada,
        IdDetalleCompra = e.IdDetalleCompra,
        CodigoEntrada = e.CodigoEntrada,
        Estado = e.Estado,
        FechaGeneracion = e.FechaGeneracion
    };
    public async Task<IEnumerable<EntradaDTO>> GetAll() => (await repository.GetAll()).Select(Map);
    public async Task<EntradaDTO?> GetById(int idEntrada)
    {
        var entity = await repository.GetById(idEntrada);
        return entity == null ? null : Map(entity);
    }
}
