using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class CompraRepository(EventosPeruIaContext context) : ICompraRepository
{
    public async Task<IEnumerable<Compra>> GetAll() =>
        await context.Compra.AsNoTracking().OrderBy(e => e.IdCompra).ToListAsync();
    public Task<Compra?> GetById(int idCompra) =>
        context.Compra.AsNoTracking().FirstOrDefaultAsync(e => e.IdCompra == idCompra);
}
