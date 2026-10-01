using Microsoft.EntityFrameworkCore;
using Eventos_Peru.Core.Core.Entities;
using Eventos_Peru.Core.Core.Interfaces;
using Eventos_Peru.Core.Infrastructure.Data;
namespace Eventos_Peru.Core.Infrastructure.Repositories;
public class ResenaRepository(EventosPeruIaContext context) : IResenaRepository
{
    public async Task<IEnumerable<Resena>> GetAll() =>
        await context.Resena.AsNoTracking().OrderBy(e => e.IdResena).ToListAsync();
    public Task<Resena?> GetById(int idResena) =>
        context.Resena.AsNoTracking().FirstOrDefaultAsync(e => e.IdResena == idResena);
}
