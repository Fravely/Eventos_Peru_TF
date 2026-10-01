using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class DetalleCompraRepository(EventosPeruIaContext context) : IDetalleCompraRepository
{
    public async Task<IEnumerable<DetalleCompra>> GetAll() =>
        await context.DetalleCompra.AsNoTracking().OrderBy(e => e.IdDetalleCompra).ToListAsync();
    public Task<DetalleCompra?> GetById(int idDetalleCompra) =>
        context.DetalleCompra.AsNoTracking().FirstOrDefaultAsync(e => e.IdDetalleCompra == idDetalleCompra);
}
