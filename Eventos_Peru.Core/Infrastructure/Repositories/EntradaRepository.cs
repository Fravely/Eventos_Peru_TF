using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class EntradaRepository(EventosPeruIaContext context) : IEntradaRepository
{
    public async Task<IEnumerable<Entrada>> GetAll() =>
        await context.Entrada.AsNoTracking().OrderBy(e => e.IdEntrada).ToListAsync();
    public Task<Entrada?> GetById(int idEntrada) =>
        context.Entrada.AsNoTracking().FirstOrDefaultAsync(e => e.IdEntrada == idEntrada);
}
